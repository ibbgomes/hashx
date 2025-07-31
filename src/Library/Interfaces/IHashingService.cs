namespace Hashx.Library;

/// <summary>
/// Defines the interface of a hashing service.
/// </summary>
public interface IHashingService
{
    /// <summary>
    /// Gets the hashing service algorithm.
    /// </summary>
    HashingAlgorithm Algorithm { get; }

    /// <summary>
    /// Gets a <see cref="HashingResult"/> from the specified <see cref="FileInfo"/>.
    /// </summary>
    /// <param name="fileInfo">The file information.</param>
    /// <returns>The hashing result.</returns>
    HashingResult GetHash(FileInfo fileInfo);
}