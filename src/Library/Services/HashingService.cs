namespace Hashx.Library;

using System.IO;
using System.Security.Cryptography;

/// <summary>
/// Defines the base implementation of a hashing service.
/// </summary>
/// <seealso cref="IHashingService"/>
internal abstract class HashingService(HashingAlgorithm algorithm, HashAlgorithm implementation) : IHashingService
{
    #region Public Properties

    /// <inheritdoc/>
    public HashingAlgorithm Algorithm { get; } = algorithm;

    #endregion

    #region Protected Properties

    /// <summary>
    /// Gets the hashing service implementation.
    /// </summary>
    protected HashAlgorithm Implementation { get; } = implementation;

    #endregion

    #region Public Methods

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

    #endregion
}