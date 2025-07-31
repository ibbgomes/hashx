namespace Hashx.Library;

using System.IO.Hashing;

/// <summary>
/// Defines the base implementation of a non-cryptographic hashing service.
/// </summary>
/// <seealso cref="IHashingService"/>
internal abstract class NonCryptographicHashingService(HashingAlgorithm algorithm, NonCryptographicHashAlgorithm implementation) : IHashingService
{
    /// <inheritdoc/>
    public HashingAlgorithm Algorithm { get; } = algorithm;

    /// <summary>
    /// Gets the hashing service implementation.
    /// </summary>
    protected NonCryptographicHashAlgorithm Implementation { get; } = implementation;

    /// <inheritdoc/>
    public HashingResult GetHash(FileInfo fileInfo)
    {
        using FileStream fileStream = new(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);

        this
            .Implementation
            .Append(fileStream);

        string hash = this
            .Implementation
            .GetCurrentHash()
            .ToHexString();

        return new(this.Algorithm, hash);
    }
}