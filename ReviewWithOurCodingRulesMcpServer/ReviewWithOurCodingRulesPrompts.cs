using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
// Add the correct namespace for ChatMessage and ChatRole below if known, for example:
using ModelContextProtocol;
using Microsoft.Extensions.AI; // or the appropriate namespace

namespace ReviewWithOurCodingRulesMcpServer;

[McpServerPromptType]
class ReviewWithOurCodingRulesPrompts
{
    [McpServerPrompt(Name = "ReviewWithOurCppCodingRule")]
    [Description("私たちのC++コーディングルールを依頼するためのプロンプト")]
    public static string PromptForCppReviewRequest() => """
        私たちのC++のためのコーディングルールを元に、コードをレビューしてください。
        """;

}

