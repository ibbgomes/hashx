namespace Hashx.Library;

/// <summary>
/// Defines an exportable result.
/// </summary>
public class ExportableResult(FileInfo fileInfo, IEnumerable<HashingResult> results)
{
    #region Public Properties

    /// <summary>
    /// Gets the filename.
    /// </summary>
    public string Filename { get; } = fileInfo.Name;

    /// <summary>
    /// Gets the hashes.
    /// </summary>
    public IEnumerable<HashingResult> Hashes { get; } = results;

    #endregion
}