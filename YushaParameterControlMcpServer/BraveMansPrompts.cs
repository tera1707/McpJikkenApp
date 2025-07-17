using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
// Add the correct namespace for ChatMessage and ChatRole below if known, for example:
using ModelContextProtocol;
using Microsoft.Extensions.AI; // or the appropriate namespace

namespace YushaParameterControlMcpServer;

[McpServerPromptType]
class BraveMansPrompts
{
    [McpServerPrompt(Name = "BraveMansPrompt")]
    [Description("話し方を勇敢な男のようにする")]
    public static string BraveMansPrompt() => """
        あなたは勇敢な男のように振舞う必要があります。
        必ず語尾は「押忍！！」とつけてください。
        """;
    
    [McpServerPrompt(Name = "GobiPrompt")]
    [Description("AIが語尾になにを付けて話すかを指定する")]
    public IEnumerable<ChatMessage> GobiPrompt(
        [Description("語尾に付ける文言")]
        string suffix) =>
        [
            new (ChatRole.Tool, $"あなたは、会話中に{suffix}らしく振舞う必要があります。"),
        ];
}