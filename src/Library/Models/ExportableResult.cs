#nullable disable warnings

namespace Hashx.Library;

using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

/// <summary>
/// Defines an exportable result.
/// </summary>
[XmlType(TypeName = "Result")]
[SuppressMessage("Design", "CA1002:DoNotExposeGenericLists", Justification = "XML Serialization.")]
public class ExportableResult
{
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ExportableResult"/> class.
    /// </summary>
    /// <param name="fileInfo">The file information.</param>
    /// <param name="results">The hashing results.</param>
    public ExportableResult(FileInfo fileInfo, IReadOnlyCollection<HashingResult> results)
    {
        ArgumentNullException.ThrowIfNull(fileInfo);

        this.Filename = fileInfo.Name;
        this.Hashes = [.. results];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExportableResult"/> class.
    /// </summary>
    private ExportableResult()
    {
        // Needed for XML serialization.
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the filename.
    /// </summary>
    public string Filename { get; init; }

    /// <summary>
    /// Gets the hashes.
    /// </summary>
    public List<HashingResult> Hashes { get; }

    #endregion
}