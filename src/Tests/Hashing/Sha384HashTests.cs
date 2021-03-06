namespace Hashx.Tests.Hashing
{
    using System;
    using System.IO;
    using Hashx.Library.Contracts;
    using Hashx.Library.Hashing;
    using Hashx.Library.Models;
    using Xunit;

    /// <summary>
    /// Defines unit tests related with the <see cref="Sha384Hash"/> type.
    /// </summary>
    [Collection(nameof(Library))]
    public sealed class Sha384HashTests
    {
        #region Constants

        private const string ExpectedAlgorithm = "SHA384";

        private const string ExpectedHash = "754b2a1b1ac5b9194c3e1a3cbcf9fbe1d8fc41328601d011926ee30cd9164e42eb009642afea9a809446025999539b62";

        #endregion

        #region Public Methods

        /// <summary>
        /// Tests the <see cref="Sha384Hash.GetHash(string)"/> method with empty arguments.
        /// </summary>
        [Fact]
        public void Sha384Hash_GetHash_Empty()
        {
            IHash hashAlgo = new Sha384Hash();

            HashResult GetHash() => hashAlgo.GetHash(string.Empty);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Sha384Hash.GetHash(FileStream)"/> method with null arguments.
        /// </summary>
        [Fact]
        public void Sha384Hash_GetHash_Null_1()
        {
            IHash hashAlgo = new Sha384Hash();

            HashResult GetHash() => hashAlgo.GetHash(null as FileStream);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Sha384Hash.GetHash(string)"/> method with null arguments.
        /// </summary>
        [Fact]
        public void Sha384Hash_GetHash_Null_2()
        {
            IHash hashAlgo = new Sha384Hash();

            HashResult GetHash() => hashAlgo.GetHash(null as string);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Sha384Hash.GetHash(FileInfo)"/> method with null arguments.
        /// </summary>
        [Fact]
        public void Sha384Hash_GetHash_Null_3()
        {
            IHash hashAlgo = new Sha384Hash();

            HashResult GetHash() => hashAlgo.GetHash(null as FileInfo);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Sha384Hash.GetHash(FileStream)"/> method with valid arguments.
        /// </summary>
        [Fact]
        public void Sha384Hash_GetHash_Valid_1()
        {
            IHash hashAlgo = new Sha384Hash();

            using FileStream fileStream = new (Constants.Data.ExpectedHashFilePath, FileMode.Open);

            HashResult hashResult = hashAlgo.GetHash(fileStream);

            Assert.Equal(ExpectedAlgorithm, hashResult.Algorithm);
            Assert.Equal(ExpectedHash, hashResult.Value);
        }

        /// <summary>
        /// Tests the <see cref="Sha384Hash.GetHash(string)"/> method with valid arguments.
        /// </summary>
        [Fact]
        public void Sha384Hash_GetHash_Valid_2()
        {
            IHash hashAlgo = new Sha384Hash();

            HashResult hashResult = hashAlgo.GetHash(Constants.Data.ExpectedHashFilePath);

            Assert.Equal(ExpectedAlgorithm, hashResult.Algorithm);
            Assert.Equal(ExpectedHash, hashResult.Value);
        }

        /// <summary>
        /// Tests the <see cref="Sha384Hash.GetHash(FileInfo)"/> method with valid arguments.
        /// </summary>
        [Fact]
        public void Sha384Hash_GetHash_Valid_3()
        {
            IHash hashAlgo = new Sha384Hash();

            FileInfo fileInfo = new (Constants.Data.ExpectedHashFilePath);

            HashResult hashResult = hashAlgo.GetHash(fileInfo);

            Assert.Equal(ExpectedAlgorithm, hashResult.Algorithm);
            Assert.Equal(ExpectedHash, hashResult.Value);
        }

        #endregion
    }
}