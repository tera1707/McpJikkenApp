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
        var url = @"https://tera1707.com/entry/2025/07/20/230051";
        return await GetMarkdownFromUrlAsync(url);
    }

    [McpServerTool, Description("Get C# Coding Rules For Code Review. 私たちのC#コーディングルールを取得する")]
    public static async Task<string> GetCsCodingRulesForCodeReview()
    {
        var url = @"https://tera1707.com/entry/2025/07/20/235616";
        return await GetMarkdownFromUrlAsync(url);
    }

    private static async Task<string> GetMarkdownFromUrlAsync(string url)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var markdown = await response.Content.ReadAsStringAsync();
        return markdown;
    }
}