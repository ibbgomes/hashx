namespace Hashx.Library;

/// <summary>
/// Defines a hashing operation result.
/// </summary>
public sealed class HashingResult(HashingAlgorithm algorithm, string hash)
{
    /// <summary>
    /// Gets the algorithm.
    /// </summary>
    public HashingAlgorithm Algorithm => algorithm;

    /// <summary>
    /// Gets the hash.
    /// </summary>
    public string Hash => hash;
}