namespace Hashx.Library.Contracts
{
    using System.IO;
    using System.Security.Cryptography;
    using Hashx.Library.Models;

    /// <summary>
    /// Defines the contract of a hashing algorithm.
    /// </summary>
    public interface IHash
    {
        #region Properties

        /// <summary>
        /// Gets or sets the hash algorithm.
        /// </summary>
        HashAlgorithm Algorithm { get; set; }

        /// <summary>
        /// Gets or sets the name of the hash algorithm.
        /// </summary>
        string Name { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a <see cref="HashResult"/> from the specified <see cref="FileStream"/>.
        /// </summary>
        /// <param name="fileStream">The file stream.</param>
        /// <returns>The hash result.</returns>
        HashResult GetHash(FileStream fileStream);

        /// <summary>
        /// Gets a <see cref="HashResult"/> from the specified path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>The hash result.</returns>
        HashResult GetHash(string filePath);

        /// <summary>
        /// Gets a <see cref="HashResult"/> from the specified <see cref="FileInfo"/>.
        /// </summary>
        /// <param name="fileInfo">The file information.</param>
        /// <returns>The hash result.</returns>
        HashResult GetHash(FileInfo fileInfo);

        #endregion
    }
}