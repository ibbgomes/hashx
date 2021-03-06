namespace Hashx.Tests.Hashing
{
    using System;
    using System.IO;
    using Hashx.Library.Contracts;
    using Hashx.Library.Hashing;
    using Hashx.Library.Models;
    using Xunit;

    /// <summary>
    /// Defines unit tests related with the <see cref="Sha256Hash"/> type.
    /// </summary>
    [Collection(nameof(Library))]
    public sealed class Sha256HashTests
    {
        #region Constants

        private const string ExpectedAlgorithm = "SHA256";

        private const string ExpectedHash = "2ad4bd189e207f62c3ef73f253ca72f528f0b37593d1fe7cea1d69136397c26c";

        #endregion

        #region Public Methods

        /// <summary>
        /// Tests the <see cref="Sha256Hash.GetHash(string)"/> method with empty arguments.
        /// </summary>
        [Fact]
        public void Sha256Hash_GetHash_Empty()
        {
            IHash hashAlgo = new Sha256Hash();

            HashResult GetHash() => hashAlgo.GetHash(string.Empty);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Sha256Hash.GetHash(FileStream)"/> method with null arguments.
        /// </summary>
        [Fact]
        public void Sha256Hash_GetHash_Null_1()
        {
            IHash hashAlgo = new Sha256Hash();

            HashResult GetHash() => hashAlgo.GetHash(null as FileStream);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Sha256Hash.GetHash(string)"/> method with null arguments.
        /// </summary>
        [Fact]
        public void Sha256Hash_GetHash_Null_2()
        {
            IHash hashAlgo = new Sha256Hash();

            HashResult GetHash() => hashAlgo.GetHash(null as string);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Sha256Hash.GetHash(FileInfo)"/> method with null arguments.
        /// </summary>
        [Fact]
        public void Sha256Hash_GetHash_Null_3()
        {
            IHash hashAlgo = new Sha256Hash();

            HashResult GetHash() => hashAlgo.GetHash(null as FileInfo);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Sha256Hash.GetHash(FileStream)"/> method with valid arguments.
        /// </summary>
        [Fact]
        public void Sha256Hash_GetHash_Valid_1()
        {
            IHash hashAlgo = new Sha256Hash();

            using FileStream fileStream = new (Constants.Data.ExpectedHashFilePath, FileMode.Open);

            HashResult hashResult = hashAlgo.GetHash(fileStream);

            Assert.Equal(ExpectedAlgorithm, hashResult.Algorithm);
            Assert.Equal(ExpectedHash, hashResult.Value);
        }

        /// <summary>
        /// Tests the <see cref="Sha256Hash.GetHash(string)"/> method with valid arguments.
        /// </summary>
        [Fact]
        public void Sha256Hash_GetHash_Valid_2()
        {
            IHash hashAlgo = new Sha256Hash();

            HashResult hashResult = hashAlgo.GetHash(Constants.Data.ExpectedHashFilePath);

            Assert.Equal(ExpectedAlgorithm, hashResult.Algorithm);
            Assert.Equal(ExpectedHash, hashResult.Value);
        }

        /// <summary>
        /// Tests the <see cref="Sha256Hash.GetHash(FileInfo)"/> method with valid arguments.
        /// </summary>
        [Fact]
        public void Sha256Hash_GetHash_Valid_3()
        {
            IHash hashAlgo = new Sha256Hash();

            FileInfo fileInfo = new (Constants.Data.ExpectedHashFilePath);

            HashResult hashResult = hashAlgo.GetHash(fileInfo);

            Assert.Equal(ExpectedAlgorithm, hashResult.Algorithm);
            Assert.Equal(ExpectedHash, hashResult.Value);
        }

        #endregion
    }
}