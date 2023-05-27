#nullable disable warnings

namespace Hashx.Library;

using System.Xml.Serialization;

/// <summary>
/// Defines a hashing operation result.
/// </summary>
[XmlType(TypeName = "Hash")]
public class HashingResult
{
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="HashingResult"/> class.
    /// </summary>
    /// <param name="algorithm">The hashing operation algorithm.</param>
    /// <param name="value">The hashing operation value.</param>
    public HashingResult(HashingAlgorithm algorithm, string value)
    {
        this.Algorithm = algorithm;
        this.Value = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HashingResult"/> class.
    /// </summary>
    private HashingResult()
    {
        // Needed for XML serialization.
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the hashing operation algorithm.
    /// </summary>
    [XmlAttribute]
    public HashingAlgorithm Algorithm { get; init; }

    /// <summary>
    /// Gets the hashing operation value.
    /// </summary>
    [XmlAttribute]
    public string Value { get; init; }

    #endregion
}