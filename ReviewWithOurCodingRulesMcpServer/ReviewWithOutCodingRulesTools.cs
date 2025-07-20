using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace ReviewWithOurCodingRulesMcpServer;

[McpServerToolType]
internal static class ReviewWithOutCodingRulesTools
{
    [McpServerTool, Description("Get C++ Coding Rules For Code Review. 私たちのC++コーディングルールを取得する")]
    public static async Task<string> GetCppCodingRulesForCodeReview()
    {
        var client = new HttpClient();
        var url = @"https://tera1707.com/entry/2025/07/20/230051";

        // URLからMarkdown情報を取得
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var markdown = await response.Content.ReadAsStringAsync();
        return markdown;
    }
}