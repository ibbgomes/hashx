namespace Hashx.Tests.Common
{
    using System.Collections.Generic;
    using System.IO;
    using Hashx.Library.Contracts;
    using Hashx.Library.Hashing;
    using Hashx.Library.Models;

    /// <summary>
    /// Defines helper methods related with models. Should be used in unit tests.
    /// </summary>
    internal static class Models
    {
        #region Internal Methods

        /// <summary>
        /// Gets an <see cref="ExportableResult"/> from the specified <see cref="FileInfo"/>.
        /// </summary>
        /// <param name="fileInfo">The file information.</param>
        /// <returns>The exportable result.</returns>
        internal static ExportableResult GetExportableResult(FileInfo fileInfo)
        {
            IEnumerable<HashResult> results = GetHashResults(fileInfo);

            return new (fileInfo, results);
        }

        /// <summary>
        /// Gets a collection of <see cref="HashResult"/> from the specified <see cref="FileInfo"/>.
        /// </summary>
        /// <param name="fileInfo">The file information.</param>
        /// <returns>The collection of hash results.</returns>
        internal static ICollection<HashResult> GetHashResults(FileInfo fileInfo)
        {
            IEnumerable<IHash> hashAlgos = GetHashAlgos();

            ICollection<HashResult> hashResults = new List<HashResult>();

            foreach (IHash hashAlgo in hashAlgos)
            {
                hashResults.Add(hashAlgo.GetHash(fileInfo));
            }

            return hashResults;
        }

        #endregion

        #region Private Methods

        private static IEnumerable<IHash> GetHashAlgos()
        {
            return new List<IHash>()
            {
                new Md5Hash(),
                new Sha1Hash(),
                new Sha256Hash(),
                new Sha384Hash(),
                new Sha512Hash(),
            };
        }

        #endregion
    }
}