using ModelContextProtocol.Server;
using System.ComponentModel;

namespace ReviewWithOurCodingRulesMcpServer;

[McpServerPromptType]
class ReviewWithOurCodingRulesPrompts
{
    [McpServerPrompt(Name = "ReviewWithOurCppCodingRule")]
    [Description("私たちのC++コーディングルールを依頼するためのプロンプト")]
    public static string PromptForCppReviewRequest() => """
        ReviewWithMyRulesのMCPサーバーを使って、私たちのC++のためのコーディングルールを元に、コードをレビューしてください。
        """;
        
    [McpServerPrompt(Name = "ReviewWithOurCsCodingRule")]
    [Description("私たちのC#コーディングルールを依頼するためのプロンプト")]
    public static string PromptForCsReviewRequest() => """
        ReviewWithMyRulesのMCPサーバーを使って、私たちのC#のためのコーディングルールを元に、コードをレビューしてください。
        """;
}

