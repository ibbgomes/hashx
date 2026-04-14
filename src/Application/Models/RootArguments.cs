namespace Hashx.Application;

using System.CommandLine;
using Hashx.Library;

/// <summary>
/// Defines the <see cref="RootCommand"/> arguments.
/// </summary>
internal sealed class RootArguments(ParseResult parseResult)
{
    /// <summary>
    /// Gets the hashing algorithms.
    /// </summary>
    internal HashingAlgorithm[] Algorithms => parseResult.GetRequiredValue(RootCommand.AlgorithmsOption);

    /// <summary>
    /// Gets the expected hash to compare against the results.
    /// </summary>
    internal string? Hash => parseResult.GetValue(RootCommand.CompareOption);

    /// <summary>
    /// Gets the input file.
    /// </summary>
    internal FileInfo? Input => parseResult.GetValue(RootCommand.InputArgument);

    /// <summary>
    /// Gets a value indicating whether to format the output as JSON.
    /// </summary>
    internal bool Json => parseResult.GetValue(RootCommand.JsonOption);
}