using ModelContextProtocol.Server;
using System.ComponentModel;

namespace ReviewWithOurCodingRulesMcpServer;

[McpServerResourceType]
internal static class CodingRuleWebPageResources
{
    [McpServerResource, Description("私たちのC#コーディングルールが記載されたwebページのURL")]
    public static string GetOurCsCodingRuleWebPageURL() => "https://tera1707.com/entry/2025/07/20/235616";

    [McpServerResource, Description("私たちのC++コーディングルールが記載されたwebページのURL")]
    public static string GetOurCppCodingRuleWebPageURL() => "https://tera1707.com/entry/2025/07/20/230051";
}
