using System;
using System.Threading.Tasks;
using SharedProject;

namespace McpJikkenApp
{
    internal class Program
    {
        static async Task<int> Main(string[] args)
        {
            // 受信データ：「Arm,100」「Leg,30」という感じで、スライダの種類と値を指定される。
            var getset = args[0];
            var kind = args[1];
            var val = args[2];

            var ret = await SendData(getset, kind, val);

            Console.WriteLine("送信処理終了");

            return ret;
        }

        static async Task<int> SendData(string getset, string kind, string val)
        {
            string response = "";
            const string pipeName = "MyPipeName";
            var pipe = new PipeServerClient();

            // クライアント側: 送信後に応答を受信
            await Task.Run(async () =>
            {
                var sendData = getset + "," + kind + "," + val;
                //await Task.Delay(1000);
                response = await pipe.SendStringAsync(pipeName, sendData);
                Console.WriteLine($"[Client] 送信: {sendData}");

                // 応答受信
                //response = await pipe.ReceiveResponseAsync(pipeName);
                Console.WriteLine($"[Client] 応答: {response}");
            });

            return int.Parse(response);
        }
    }
}
