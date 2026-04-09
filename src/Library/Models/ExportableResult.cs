namespace Hashx.Library;

/// <summary>
/// Defines an exportable result.
/// </summary>
public class ExportableResult(FileInfo? fileInfo, IEnumerable<HashingResult> results)
{
    /// <summary>
    /// Gets the source.
    /// </summary>
    public string Source => fileInfo?.Name ?? "stdin";

    /// <summary>
    /// Gets the hashes.
    /// </summary>
    public IReadOnlyDictionary<string, string> Hashes => results.ToDictionary(r => r.Algorithm.ToString().ToLowerInvariant(), r => r.Value);
}