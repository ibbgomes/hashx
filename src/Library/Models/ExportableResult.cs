#nullable disable warnings

namespace Hashx.Library;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
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
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        this.Filename = fileInfo.Name;

        this.Hashes = results
            .OrderBy(x => x.Algorithm)
            .ToList();
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