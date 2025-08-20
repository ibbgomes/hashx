namespace Hashx.Application;

using System.CommandLine;
using System.CommandLine.Help;
using System.CommandLine.Invocation;
using Hashx.Library;

/// <summary>
/// Provides custom information for the help option.
/// </summary>
/// <seealso cref="SynchronousCommandLineAction"/>
internal sealed class CustomAction(HelpAction helpAction) : SynchronousCommandLineAction
{
    /// <inheritdoc/>
    public override int Invoke(ParseResult parseResult)
    {
        int result = helpAction.Invoke(parseResult);

        PrintAlgorithms();

        PrintExitCodes();

        return result;
    }

    private static void PrintAlgorithms()
    {
        IEnumerable<string> algorithms = Enum
            .GetNames<HashingAlgorithm>()
            .Select(a => a.ToLowerInvariant())
            .Order();

        string algorithmsList = string.Join(", ", algorithms);

        ConsoleWriter.WriteLine($"Algorithms:\n  {algorithmsList}");
    }

    private static void PrintExitCodes()
    {
        ConsoleWriter.WriteLine("\nExit Codes:");
        ConsoleWriter.WriteLine("  0  Success");
        ConsoleWriter.WriteLine("  1  Processing error");
        ConsoleWriter.WriteLine("  2  Checksum mismatch");
    }
}