namespace Hashx.Tests.Hashing
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using Hashx.Library.Contracts;
    using Hashx.Library.Hashing;
    using Hashx.Library.Models;
    using Xunit;

    /// <summary>
    /// Defines unit tests related with the <see cref="Sha512Hash"/> type.
    /// </summary>
    [Collection(nameof(Library))]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Unit test.")]
    public sealed class Sha512HashTests
    {
        #region Constants

        private const string ExpectedAlgorithm = "SHA512";

        private const string ExpectedHash = "eef9995abc271935a9fe5be4c8c758fe03becb40e77a42d0feb83f5c191551ff896ae4139f496d40e904f29896eb61cfa7b275775c2b4763ce40ff5d9ee25870";

        #endregion

        #region Public Methods

        /// <summary>
        /// Tests the <see cref="Sha512Hash.GetHash(string)"/> method with empty arguments.
        /// </summary>
        [Fact]
        public void Sha512Hash_GetHash_Empty()
        {
            IHash hashAlgo = new Sha512Hash();

            HashResult GetHash() => hashAlgo.GetHash(string.Empty);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Sha512Hash.GetHash(FileStream)"/> method with null arguments.
        /// </summary>
        [Fact]
        public void Sha512Hash_GetHash_Null_1()
        {
            IHash hashAlgo = new Sha512Hash();

            HashResult GetHash() => hashAlgo.GetHash(null as FileStream);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Sha512Hash.GetHash(string)"/> method with null arguments.
        /// </summary>
        [Fact]
        public void Sha512Hash_GetHash_Null_2()
        {
            IHash hashAlgo = new Sha512Hash();

            HashResult GetHash() => hashAlgo.GetHash(null as string);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Sha512Hash.GetHash(FileInfo)"/> method with null arguments.
        /// </summary>
        [Fact]
        public void Sha512Hash_GetHash_Null_3()
        {
            IHash hashAlgo = new Sha512Hash();

            HashResult GetHash() => hashAlgo.GetHash(null as FileInfo);

            Assert.Throws<ArgumentNullException>(GetHash);
        }

        /// <summary>
        /// Tests the <see cref="Sha512Hash.GetHash(FileStream)"/> method with valid arguments.
        /// </summary>
        [Fact]
        public void Sha512Hash_GetHash_Valid_1()
        {
            IHash hashAlgo = new Sha512Hash();

            using FileStream fileStream = new FileStream(Constants.Data.ExpectedHashFilePath, FileMode.Open);

            HashResult hashResult = hashAlgo.GetHash(fileStream);

            Assert.Equal(ExpectedAlgorithm, hashResult.Algorithm);
            Assert.Equal(ExpectedHash, hashResult.Value);
        }

        /// <summary>
        /// Tests the <see cref="Sha512Hash.GetHash(string)"/> method with valid arguments.
        /// </summary>
        [Fact]
        public void Sha512Hash_GetHash_Valid_2()
        {
            IHash hashAlgo = new Sha512Hash();

            HashResult hashResult = hashAlgo.GetHash(Constants.Data.ExpectedHashFilePath);

            Assert.Equal(ExpectedAlgorithm, hashResult.Algorithm);
            Assert.Equal(ExpectedHash, hashResult.Value);
        }

        /// <summary>
        /// Tests the <see cref="Sha512Hash.GetHash(FileInfo)"/> method with valid arguments.
        /// </summary>
        [Fact]
        public void Sha512Hash_GetHash_Valid_3()
        {
            IHash hashAlgo = new Sha512Hash();

            FileInfo fileInfo = new FileInfo(Constants.Data.ExpectedHashFilePath);

            HashResult hashResult = hashAlgo.GetHash(fileInfo);

            Assert.Equal(ExpectedAlgorithm, hashResult.Algorithm);
            Assert.Equal(ExpectedHash, hashResult.Value);
        }

        #endregion
    }
}