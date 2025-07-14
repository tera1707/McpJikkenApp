using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace YushaParameterControlMcpServer;

[McpServerToolType]
internal static class BraveMansTools
{
    static string BraveMansParameterAppPath = @"C:\Program Files\BraveMan\McpJikkenApp.exe";

    [McpServerTool, Description("Set Blave man's Arm power value.")]
    public static async Task<string> SetBlaveMansArmPower(
        [Description("The Power Value for Arm.")] double armPower)
    {
        // 引数付きでexeを起動
        var psi = new ProcessStartInfo
        {
            FileName = BraveMansParameterAppPath,
            WorkingDirectory = Path.GetDirectoryName(BraveMansParameterAppPath),
            Arguments = "Arm " + armPower.ToString(CultureInfo.InvariantCulture),
            UseShellExecute = true
        };
        var p = Process.Start(psi);

        return $"""
                    Result: {"OK"}
                    """;
    }

    [McpServerTool, Description("Set Blave man's Leg power value.")]
    public static async Task<string> SetBlaveMansLegPower(
        [Description("The Power Value for Leg.")] double armPower)
    {
        // 引数付きでexeを起動
        var psi = new ProcessStartInfo
        {
            FileName = BraveMansParameterAppPath,
            Arguments = "Leg," + armPower.ToString(CultureInfo.InvariantCulture),
            UseShellExecute = false
        };
        var p = Process.Start(psi);

        return $"""
                    Result: {"OK"}
                    """;
    }




    //[McpServerTool, Description("Get weather alerts for a US state.")]
    //public static async Task<string> SetAlerts(
    //    HttpClient client,
    //    [Description("The Power Value for Arm.")] double arm)
    //{
    //    using var jsonDocument = await client.ReadJsonDocumentAsync($"/alerts/active/area/{state}");
    //    var jsonElement = jsonDocument.RootElement;
    //    var alerts = jsonElement.GetProperty("features").EnumerateArray();

    //    if (!alerts.Any())
    //    {
    //        return "No active alerts for this state.";
    //    }

    //    return string.Join("\n--\n", alerts.Select(alert =>
    //    {
    //        JsonElement properties = alert.GetProperty("properties");
    //        return $"""
    //                Event: {properties.GetProperty("zevent").GetString()}
    //                Area: {properties.GetProperty("areaDesc").GetString()}
    //                Severity: {properties.GetProperty("severity").GetString()}
    //                Description: {properties.GetProperty("description").GetString()}
    //                Instruction: {properties.GetProperty("instruction").GetString()}
    //                """;
    //    }));
    //}
}
