using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace SharedProject;

internal class PipeServerClient
{
    // 名前付きパイプサーバー: 指定したパイプ名で待機し、受信した文字列を返す
    public async Task<string> WaitForStringAsync(string pipeName)
    {
        using var server = new NamedPipeServerStream(pipeName, PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
        await server.WaitForConnectionAsync();
        var buffer = new byte[4096];
        int bytesRead = await server.ReadAsync(buffer, 0, buffer.Length);
        return Encoding.UTF8.GetString(buffer, 0, bytesRead);
    }

    // 名前付きパイプクライアント: 指定したパイプ名で接続し、文字列を送信する
    public async Task<string> SendStringAsync(string pipeName, string message)
    {
        using var client = new NamedPipeClientStream(".", pipeName, PipeDirection.InOut, PipeOptions.Asynchronous);
        await client.ConnectAsync();
        var buffer = Encoding.UTF8.GetBytes(message);
        await client.WriteAsync(buffer, 0, buffer.Length);
        await client.FlushAsync();


        var buffer2 = new byte[4096];
        int bytesRead = await client.ReadAsync(buffer2, 0, buffer2.Length);
        return Encoding.UTF8.GetString(buffer2, 0, bytesRead);
    }

    // 名前付きパイプサーバー: 指定したパイプ名で待機し、受信した文字列を返し、応答も返す
    public async Task<string> WaitForStringAndRespondAsync(string pipeName, Func<string, string> responseProvider)
    {
        using var server = new NamedPipeServerStream(pipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
        await server.WaitForConnectionAsync();
        var buffer = new byte[4096];
        int bytesRead = await server.ReadAsync(buffer, 0, buffer.Length);
        string received = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        // 応答文字列を生成
        string response = responseProvider(received);
        if (!string.IsNullOrEmpty(response))
        {
            var responseBytes = Encoding.UTF8.GetBytes(response);
            await server.WriteAsync(responseBytes, 0, responseBytes.Length);
            await server.FlushAsync();
        }
        return received;
    }

    // 名前付きパイプクライアント: 応答を受信する
    public async Task<string> ReceiveResponseAsync(string pipeName)
    {
        using var client = new NamedPipeClientStream(".", pipeName, PipeDirection.In, PipeOptions.Asynchronous);
        await client.ConnectAsync();
        var buffer = new byte[4096];
        int bytesRead = await client.ReadAsync(buffer, 0, buffer.Length);
        return Encoding.UTF8.GetString(buffer, 0, bytesRead);
    }
}
