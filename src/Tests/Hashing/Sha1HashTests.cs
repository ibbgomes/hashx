namespace Hashx.Tests.Hashing
{
    using System;
    using System.IO;
    using Hashx.Library.Contracts;
    using Hashx.Library.Hashing;
    using Hashx.Library.Models;
    using Xunit;

    /// <summary>
    /// Defines unit tests related with the <see cref="Sha1Hash"/> type.
    /// </summary>
    [Collection(nameof(Library))]
    public sealed class Sha1HashTests
    {
        #region Constants

        private const string ExpectedAlgorithm = "SHA1";

        private const string ExpectedHash = "baf173ab3fcbddee35d97884fea9aff37a47d96f";

        #endregion

        #region Public Methods

        /// <summary>
        /// Tests the <see cref="Sha1Hash.GetHash(string)"/> method with empty arguments.
        /// </summary>
        [Fact]
        public void Sha1Hash_GetHash_Empty()
        {
            IHash hashAlgo = new Sha1Hash();

            HashResult GetHash() => hashAlgo.GetHash(string.Empty);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Sha1Hash.GetHash(FileStream)"/> method with null arguments.
        /// </summary>
        [Fact]
        public void Sha1Hash_GetHash_Null_1()
        {
            IHash hashAlgo = new Sha1Hash();

            HashResult GetHash() => hashAlgo.GetHash(null as FileStream);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Sha1Hash.GetHash(string)"/> method with null arguments.
        /// </summary>
        [Fact]
        public void Sha1Hash_GetHash_Null_2()
        {
            IHash hashAlgo = new Sha1Hash();

            HashResult GetHash() => hashAlgo.GetHash(null as string);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Sha1Hash.GetHash(FileInfo)"/> method with null arguments.
        /// </summary>
        [Fact]
        public void Sha1Hash_GetHash_Null_3()
        {
            IHash hashAlgo = new Sha1Hash();

            HashResult GetHash() => hashAlgo.GetHash(null as FileInfo);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Sha1Hash.GetHash(FileStream)"/> method with valid arguments.
        /// </summary>
        [Fact]
        public void Sha1Hash_GetHash_Valid_1()
        {
            IHash hashAlgo = new Sha1Hash();

            using FileStream fileStream = new (Constants.Data.ExpectedHashFilePath, FileMode.Open);

            HashResult hashResult = hashAlgo.GetHash(fileStream);

            Assert.Equal(ExpectedAlgorithm, hashResult.Algorithm);
            Assert.Equal(ExpectedHash, hashResult.Value);
        }

        /// <summary>
        /// Tests the <see cref="Sha1Hash.GetHash(string)"/> method with valid arguments.
        /// </summary>
        [Fact]
        public void Sha1Hash_GetHash_Valid_2()
        {
            IHash hashAlgo = new Sha1Hash();

            HashResult hashResult = hashAlgo.GetHash(Constants.Data.ExpectedHashFilePath);

            Assert.Equal(ExpectedAlgorithm, hashResult.Algorithm);
            Assert.Equal(ExpectedHash, hashResult.Value);
        }

        /// <summary>
        /// Tests the <see cref="Sha1Hash.GetHash(FileInfo)"/> method with valid arguments.
        /// </summary>
        [Fact]
        public void Sha1Hash_GetHash_Valid_3()
        {
            IHash hashAlgo = new Sha1Hash();

            FileInfo fileInfo = new (Constants.Data.ExpectedHashFilePath);

            HashResult hashResult = hashAlgo.GetHash(fileInfo);

            Assert.Equal(ExpectedAlgorithm, hashResult.Algorithm);
            Assert.Equal(ExpectedHash, hashResult.Value);
        }

        #endregion
    }
}