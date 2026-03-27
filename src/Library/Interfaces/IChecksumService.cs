namespace Hashx.Library;

/// <summary>
/// Defines a service for computing checksums.
/// </summary>
public interface IChecksumService
{
    /// <summary>
    /// Gets the checksums from the specified <see cref="Stream"/> using the provided <see cref="HashingAlgorithm"/> collection.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <param name="algorithms">The algorithms.</param>
    /// <returns>The checksums.</returns>
    IReadOnlyCollection<HashingResult> GetChecksums(Stream stream, params IEnumerable<HashingAlgorithm> algorithms);
}