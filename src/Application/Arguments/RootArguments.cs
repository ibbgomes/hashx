namespace Hashx.Application;

using System.IO;
using Hashx.Library;

/// <summary>
/// Defines the <see cref="RootCommand"/> arguments.
/// </summary>
internal sealed class RootArguments
{
    #region Public Properties

    /// <summary>
    /// Gets the hashing algorithms.
    /// </summary>
    internal HashingAlgorithm[] Algorithms { get; init; } = default!;

    /// <summary>
    /// Gets the checksum that should be compared against the results.
    /// </summary>
    internal string? Checksum { get; init; }

    /// <summary>
    /// Gets the input file.
    /// </summary>
    internal FileInfo Input { get; init; } = default!;

    /// <summary>
    /// Gets a value indicating whether the results should be printed in JSON.
    /// </summary>
    internal bool Json { get; init; }

    /// <summary>
    /// Gets a value indicating whether the results should be printed in XML.
    /// </summary>
    internal bool Xml { get; init; }

    #endregion
}