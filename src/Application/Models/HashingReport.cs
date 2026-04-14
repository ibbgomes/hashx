namespace Hashx.Application;

using Hashx.Library;

/// <summary>
/// Defines a hashing report.
/// </summary>
internal sealed class HashingReport(FileInfo? file, IEnumerable<HashingResult> results)
{
    /// <summary>
    /// Gets the source.
    /// </summary>
    public string Source => file?.Name ?? "stdin";

    /// <summary>
    /// Gets the hashes.
    /// </summary>
    public IReadOnlyDictionary<string, string> Hashes => results.ToDictionary(r => r.Algorithm.ToString().ToLowerInvariant(), r => r.Hash);
}