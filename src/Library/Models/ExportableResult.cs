namespace Hashx.Library;

/// <summary>
/// Defines an exportable result.
/// </summary>
public class ExportableResult(FileInfo fileInfo, IEnumerable<HashingResult> results)
{
    /// <summary>
    /// Gets the filename.
    /// </summary>
    public string Filename { get; } = fileInfo.Name;

    /// <summary>
    /// Gets the hashes.
    /// </summary>
    public IDictionary<string, string> Hashes { get; } = results.ToDictionary(r => r.Algorithm.ToString().ToLowerInvariant(), r => r.Value);
}