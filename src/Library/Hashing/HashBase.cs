namespace Hashx.Library.Hashing
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Security.Cryptography;
    using Hashx.Library.Contracts;
    using Hashx.Library.Models;

    /// <summary>
    /// Defines the base implementation of <see cref="IHash"/>.
    /// </summary>
    /// <seealso cref="Hashx.Library.Contracts.IHash"/>
    public abstract class HashBase : IHash
    {
        #region Constants

        private const string StringToReplace = "-";

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HashBase"/> class.
        /// </summary>
        protected HashBase()
        {
        }

        #endregion

        #region Public Properties

        /// <inheritdoc/>
        public HashAlgorithm Algorithm { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        #endregion

        #region Public Method

        /// <inheritdoc/>
        public HashResult GetHash(FileStream fileStream)
        {
            if (fileStream is null)
            {
                throw new ArgumentNullException(nameof(fileStream));
            }

            try
            {
                string hashValue = Normalize(this.Algorithm.ComputeHash(fileStream));

                return new HashResult(this.Name, hashValue);
            }
            catch
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public HashResult GetHash(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            using FileStream fileStream = new FileStream(filePath, FileMode.Open);

            return this.GetHash(fileStream);
        }

        /// <inheritdoc/>
        public HashResult GetHash(FileInfo fileInfo)
        {
            if (fileInfo is null)
            {
                throw new ArgumentNullException(nameof(fileInfo));
            }

            return this.GetHash(fileInfo.FullName);
        }

        #endregion

        #region Private Methods

        private static string Normalize(byte[] hashValue)
        {
            return BitConverter.ToString(hashValue)
                 .Replace(StringToReplace, string.Empty, StringComparison.OrdinalIgnoreCase)
                 .ToLower(CultureInfo.InvariantCulture);
        }

        #endregion
    }
}