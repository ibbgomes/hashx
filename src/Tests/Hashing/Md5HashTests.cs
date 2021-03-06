namespace Hashx.Tests.Hashing
{
    using System;
    using System.IO;
    using Hashx.Library.Contracts;
    using Hashx.Library.Hashing;
    using Hashx.Library.Models;
    using Xunit;

    /// <summary>
    /// Defines unit tests related with the <see cref="Md5Hash"/> type.
    /// </summary>
    [Collection(nameof(Library))]
    public sealed class Md5HashTests
    {
        #region Constants

        private const string ExpectedAlgorithm = "MD5";

        private const string ExpectedHash = "72513b3437f09b729bbc6011949debf9";

        #endregion

        #region Public Methods

        /// <summary>
        /// Tests the <see cref="Md5Hash.GetHash(string)"/> method with empty arguments.
        /// </summary>
        [Fact]
        public void Md5Hash_GetHash_Empty()
        {
            IHash hashAlgo = new Md5Hash();

            HashResult GetHash() => hashAlgo.GetHash(string.Empty);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Md5Hash.GetHash(FileStream)"/> method with null arguments.
        /// </summary>
        [Fact]
        public void Md5Hash_GetHash_Null_1()
        {
            IHash hashAlgo = new Md5Hash();

            HashResult GetHash() => hashAlgo.GetHash(null as FileStream);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Md5Hash.GetHash(string)"/> method with null arguments.
        /// </summary>
        [Fact]
        public void Md5Hash_GetHash_Null_2()
        {
            IHash hashAlgo = new Md5Hash();

            HashResult GetHash() => hashAlgo.GetHash(null as string);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Md5Hash.GetHash(FileInfo)"/> method with null arguments.
        /// </summary>
        [Fact]
        public void Md5Hash_GetHash_Null_3()
        {
            IHash hashAlgo = new Md5Hash();

            HashResult GetHash() => hashAlgo.GetHash(null as FileInfo);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Md5Hash.GetHash(FileStream)"/> method with valid arguments.
        /// </summary>
        [Fact]
        public void Md5Hash_GetHash_Valid_1()
        {
            IHash hashAlgo = new Md5Hash();

            using FileStream fileStream = new (Constants.Data.ExpectedHashFilePath, FileMode.Open);

            HashResult hashResult = hashAlgo.GetHash(fileStream);

            Assert.Equal(ExpectedAlgorithm, hashResult.Algorithm);
            Assert.Equal(ExpectedHash, hashResult.Value);
        }

        /// <summary>
        /// Tests the <see cref="Md5Hash.GetHash(string)"/> method with valid arguments.
        /// </summary>
        [Fact]
        public void Md5Hash_GetHash_Valid_2()
        {
            IHash hashAlgo = new Md5Hash();

            HashResult hashResult = hashAlgo.GetHash(Constants.Data.ExpectedHashFilePath);

            Assert.Equal(ExpectedAlgorithm, hashResult.Algorithm);
            Assert.Equal(ExpectedHash, hashResult.Value);
        }

        /// <summary>
        /// Tests the <see cref="Md5Hash.GetHash(FileInfo)"/> method with valid arguments.
        /// </summary>
        [Fact]
        public void Md5Hash_GetHash_Valid_3()
        {
            IHash hashAlgo = new Md5Hash();

            FileInfo fileInfo = new (Constants.Data.ExpectedHashFilePath);

            HashResult hashResult = hashAlgo.GetHash(fileInfo);

            Assert.Equal(ExpectedAlgorithm, hashResult.Algorithm);
            Assert.Equal(ExpectedHash, hashResult.Value);
        }

        #endregion
    }
}