namespace Hashx.Library;

/// <summary>
/// Defines a service for computing multiple hashes from a single input source.
/// </summary>
public interface IMultiHashingService
{
    /// <summary>
    /// Gets the hashes from the specified <see cref="Stream"/> using the provided <see cref="HashingAlgorithm"/> collection.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <param name="algorithms">The algorithms.</param>
    /// <returns>The hashes.</returns>
    IReadOnlyCollection<HashingResult> GetHashes(Stream stream, params IEnumerable<HashingAlgorithm> algorithms);
}