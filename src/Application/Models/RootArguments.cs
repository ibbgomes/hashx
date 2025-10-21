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
    /// Gets the checksum that should be compared against the results.
    /// </summary>
    internal string? Checksum => parseResult.GetValue(RootCommand.CompareOption);

    /// <summary>
    /// Gets the input file.
    /// </summary>
    internal FileInfo Input => parseResult.GetRequiredValue(RootCommand.InputArgument);

    /// <summary>
    /// Gets a value indicating whether the results should be printed in JSON.
    /// </summary>
    internal bool Json => parseResult.GetValue(RootCommand.JsonOption);
}