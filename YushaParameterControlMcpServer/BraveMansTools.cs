using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace YushaParameterControlMcpServer;

[McpServerToolType]
internal static class BraveMansTools
{
    static string BraveMansParameterAppPath = @"C:\Program Files\McpJikken\McpJikkenApp.exe";

    // set

    [McpServerTool, Description("Set Blave man's Arm power value.")]
    public static string SetBlaveMansArmPower(
        [Description("The Power Value for Arm.")] double armPower)
    {
        // 引数付きでexeを起動
        var psi = new ProcessStartInfo
        {
            FileName = BraveMansParameterAppPath,
            WorkingDirectory = Path.GetDirectoryName(BraveMansParameterAppPath),
            Arguments = "Set Arm " + armPower.ToString(CultureInfo.InvariantCulture),
            UseShellExecute = true
        };
        var p = Process.Start(psi);

        return $"""
                    Result: {"OK"}
                    """;
    }

    [McpServerTool, Description("Set Blave man's Leg power value.")]
    public static string SetBlaveMansLegPower(
        [Description("The Power Value for Leg.")] double armPower)
    {
        // 引数付きでexeを起動
        var psi = new ProcessStartInfo
        {
            FileName = BraveMansParameterAppPath,
            Arguments = "Set Leg " + armPower.ToString(CultureInfo.InvariantCulture),
            UseShellExecute = false
        };
        var p = Process.Start(psi);

        return $"""
                    Result: {"OK"}
                    """;
    }


    //get 

    [McpServerTool, Description("Get Blave man's Arm power value.")]
    public static string GetBlaveMansArmPower()
    {
        // 引数付きでexeを起動
        var psi = new ProcessStartInfo
        {
            FileName = BraveMansParameterAppPath,
            WorkingDirectory = Path.GetDirectoryName(BraveMansParameterAppPath),
            Arguments = "Get Arm 0",
            UseShellExecute = false // 標準出力不要なのでfalse
        };
        var p = Process.Start(psi);
        p?.WaitForExit();
        int exitCode = p?.ExitCode ?? -1;
        
        return $"""
                    ArmPower: {exitCode}
                    """;
    }

    [McpServerTool, Description("Get Blave man's Leg power value.")]
    public static string GetBlaveMansLegPower()
    {
        // 引数付きでexeを起動
        var psi = new ProcessStartInfo
        {
            FileName = BraveMansParameterAppPath,
            WorkingDirectory = Path.GetDirectoryName(BraveMansParameterAppPath),
            Arguments = "Get Leg 0",
            UseShellExecute = false // 標準出力不要なのでfalse
        };
        var p = Process.Start(psi);
        p?.WaitForExit();
        int exitCode = p?.ExitCode ?? -1;
        
        return $"""
                    LegPower: {exitCode}
                    """;
    }
}
