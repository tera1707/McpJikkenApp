using System;
using System.Threading.Tasks;
using SharedProject;

namespace McpJikkenApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Thread.Sleep(2000);
            // 受信データ：「Arm,100」「Leg,30」という感じで、スライダの種類と値を指定される。
            var kind = args[0];
            var val = args[1];

            await Task.WhenAll(SendData(kind, val));

            Console.WriteLine("送信処理終了");
        }

        static async Task SendData(string kind, string val)
        {
            const string pipeName = "MyPipeName";
            var pipe = new PipeServerClient();

            // クライアント側: 5秒ごとに送信
            await Task.Run(async () =>
            {
                //while (true)
                {
                    var sendData = kind + "," + val;

                    await Task.Delay(1000);
                    await pipe.SendStringAsync(pipeName, sendData);
                    Console.WriteLine($"[Client] 送信: {sendData}");
                }
            });
        }
    }
}
