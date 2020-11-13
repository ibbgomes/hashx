namespace Hashx.Tests.Models
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Hashx.Library.Models;
    using Xunit;

    /// <summary>
    /// Defines unit tests related with the <see cref="HashResult"/> type.
    /// </summary>
    [Collection(nameof(Library))]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Unit test.")]
    public sealed class HashResultTests
    {
        #region Public Methods

        /// <summary>
        /// Tests the <see cref="HashResult(string, string)"/> constructor with empty arguments.
        /// </summary>
        [Fact]
        public void HashResult_Empty_1()
        {
            static HashResult Constructor() => new HashResult(string.Empty, string.Empty);

            Assert.Throws<ArgumentNullException>(Constructor);
        }

        /// <summary>
        /// Tests the <see cref="HashResult(string, string)"/> constructor with empty arguments.
        /// </summary>
        [Fact]
        public void HashResult_Empty_2()
        {
            static HashResult Constructor() => new HashResult(Constants.Samples.String, string.Empty);

            Assert.Throws<ArgumentNullException>(Constructor);
        }

        /// <summary>
        /// Tests the <see cref="HashResult(string, string)"/> constructor with empty arguments.
        /// </summary>
        [Fact]
        public void HashResult_Empty_3()
        {
            static HashResult Constructor() => new HashResult(string.Empty, Constants.Samples.String);

            Assert.Throws<ArgumentNullException>(Constructor);
        }

        /// <summary>
        /// Tests the <see cref="HashResult(string, string)"/> constructor with null arguments.
        /// </summary>
        [Fact]
        public void HashResult_Null_1()
        {
            static HashResult Constructor() => new HashResult(null, null);

            Assert.Throws<ArgumentNullException>(Constructor);
        }

        /// <summary>
        /// Tests the <see cref="HashResult(string, string)"/> constructor with null arguments.
        /// </summary>
        [Fact]
        public void HashResult_Null_2()
        {
            static HashResult Constructor() => new HashResult(Constants.Samples.String, null);

            Assert.Throws<ArgumentNullException>(Constructor);
        }

        /// <summary>
        /// Tests the <see cref="HashResult(string, string)"/> constructor with null arguments.
        /// </summary>
        [Fact]
        public void HashResult_Null_3()
        {
            static HashResult Constructor() => new HashResult(null, Constants.Samples.String);

            Assert.Throws<ArgumentNullException>(Constructor);
        }

        /// <summary>
        /// Tests the <see cref="HashResult(string, string)"/> constructor with valid arguments.
        /// </summary>
        [Fact]
        public void HashResult_Valid()
        {
            HashResult hashResult = new HashResult(Constants.Samples.String, Constants.Samples.String);

            Assert.NotNull(hashResult);
            Assert.NotNull(hashResult.Algorithm);
            Assert.NotNull(hashResult.Value);
            Assert.NotEmpty(hashResult.Algorithm);
            Assert.NotEmpty(hashResult.Value);
        }

        #endregion
    }
}