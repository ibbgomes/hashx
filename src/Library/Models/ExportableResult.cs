namespace Hashx.Library;

/// <summary>
/// Defines an exportable result.
/// </summary>
public class ExportableResult(FileInfo fileInfo, IEnumerable<HashingResult> results)
{
    /// <summary>
    /// Gets the filename.
    /// </summary>
    public string Filename => fileInfo.Name;

    /// <summary>
    /// Gets the hashes.
    /// </summary>
    public IDictionary<string, string> Hashes => results.ToDictionary(r => r.Algorithm.ToString().ToLowerInvariant(), r => r.Value);
}