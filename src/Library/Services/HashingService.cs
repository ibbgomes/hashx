namespace Hashx.Library;

using System.IO;
using System.Security.Cryptography;

/// <summary>
/// Defines the base implementation of a hashing service.
/// </summary>
/// <seealso cref="IHashingService"/>
internal abstract class HashingService : IHashingService
{
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="HashingService"/> class.
    /// </summary>
    /// <param name="algorithm">The algorithm.</param>
    /// <param name="implementation">The implementation.</param>
    protected HashingService(HashingAlgorithm algorithm, HashAlgorithm implementation)
    {
        this.Algorithm = algorithm;
        this.Implementation = implementation;
    }

    #endregion

    #region Public Properties

    /// <inheritdoc/>
    public HashingAlgorithm Algorithm { get; }

    #endregion

    #region Protected Properties

    /// <summary>
    /// Gets the hashing service implementation.
    /// </summary>
    protected HashAlgorithm Implementation { get; }

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