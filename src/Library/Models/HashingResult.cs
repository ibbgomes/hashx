namespace Hashx.Library;

/// <summary>
/// Defines a hashing operation result.
/// </summary>
public class HashingResult(HashingAlgorithm algorithm, string value)
{
    /// <summary>
    /// Gets the hashing operation algorithm.
    /// </summary>
    public HashingAlgorithm Algorithm => algorithm;

    /// <summary>
    /// Gets the hashing operation value.
    /// </summary>
    public string Value => value;
}