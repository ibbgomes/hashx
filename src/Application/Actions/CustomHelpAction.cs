namespace Hashx.Application;

using System.CommandLine;
using System.CommandLine.Help;
using System.CommandLine.Invocation;
using Hashx.Library;

/// <summary>
/// Defines an action that provides custom information for the help option.
/// </summary>
/// <seealso cref="SynchronousCommandLineAction"/>
internal sealed class CustomHelpAction(HelpAction helpAction) : SynchronousCommandLineAction
{
    /// <inheritdoc/>
    public override int Invoke(ParseResult parseResult)
    {
        int result = helpAction.Invoke(parseResult);

        InvocationContext context = new(parseResult);

        PrintAlgorithms(context);

        PrintExitCodes(context);

        return result;
    }

    private static void PrintAlgorithms(InvocationContext context)
    {
        IEnumerable<string> algorithms = Enum
            .GetNames<HashingAlgorithm>()
            .Select(a => a.ToLowerInvariant())
            .Order();

        string algorithmsList = string.Join(", ", algorithms);

        context.Output.WriteLine($"Algorithms:");
        context.Output.WriteLine($"  {algorithmsList}");
    }

    private static void PrintExitCodes(InvocationContext context)
    {
        context.Output.WriteLine();
        context.Output.WriteLine("Exit Codes:");
        context.Output.WriteLine("  0  Success");
        context.Output.WriteLine("  1  Processing error");
        context.Output.WriteLine("  2  Checksum mismatch");
    }
}