namespace Hashx.Library;

using System.Security.Cryptography;

/// <summary>
/// Defines the base implementation of a cryptographic hashing service.
/// </summary>
/// <seealso cref="IHashingService"/>
internal abstract class CryptographicHashingService(HashingAlgorithm algorithm, HashAlgorithm implementation) : IHashingService
{
    /// <inheritdoc/>
    public HashingAlgorithm Algorithm { get; } = algorithm;

    /// <summary>
    /// Gets the hashing service implementation.
    /// </summary>
    protected HashAlgorithm Implementation { get; } = implementation;

    /// <inheritdoc/>
    public HashingResult GetHash(FileInfo fileInfo)
    {
        using FileStream fileStream = new(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);

        string hash = this
            .Implementation
            .ComputeHash(fileStream)
            .ToHexString();

        return new(this.Algorithm, hash);
    }
}