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
    public async Task SendStringAsync(string pipeName, string message)
    {
        using var client = new NamedPipeClientStream(".", pipeName, PipeDirection.Out, PipeOptions.Asynchronous);
        await client.ConnectAsync();
        var buffer = Encoding.UTF8.GetBytes(message);
        await client.WriteAsync(buffer, 0, buffer.Length);
        await client.FlushAsync();
    }
}
