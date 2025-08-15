namespace Hashx.Application;

using System;
using System.CommandLine;
using System.CommandLine.Help;
using System.CommandLine.Invocation;
using Hashx.Library;

/// <summary>
/// Provides algorithms information for the command line help.
/// </summary>
/// <seealso cref="SynchronousCommandLineAction"/>
internal sealed class AlgorithmsAction(HelpAction helpAction) : SynchronousCommandLineAction
{
    /// <inheritdoc/>
    public override int Invoke(ParseResult parseResult)
    {
        int result = helpAction.Invoke(parseResult);

        IEnumerable<string> algorithms = Enum
            .GetNames<HashingAlgorithm>()
            .Select(a => a.ToLowerInvariant())
            .Order();

        string algorithmsList = string.Join(", ", algorithms);

        ConsoleWriter.Write($"Algorithms:\n  {algorithmsList}");

        return result;
    }
}