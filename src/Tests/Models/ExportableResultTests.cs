namespace Hashx.Tests.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Hashx.Library.Models;
    using Hashx.Tests.Common;
    using Xunit;

    /// <summary>
    /// Defines unit tests related with the <see cref="ExportableResult"/> type.
    /// </summary>
    [Collection(nameof(Library))]
    public sealed class ExportableResultTests
    {
        #region Public Methods

        /// <summary>
        /// Tests the <see cref="ExportableResult"/> constructor with empty arguments.
        /// </summary>
        [Fact]
        public void ExportableResult_Empty()
        {
            FileInfo fileInfo = new (Constants.Data.ExpectedHashFilePath);

            ExportableResult Constructor() => new (fileInfo, new List<HashResult>());

            Assert.Throws<ArgumentNullException>(Constructor);
        }

        /// <summary>
        /// Tests the <see cref="ExportableResult"/> constructor with null arguments.
        /// </summary>
        [Fact]
        public void ExportableResult_Null_1()
        {
            static ExportableResult Constructor() => new (null, null);

            Assert.Throws<ArgumentNullException>(Constructor);
        }

        /// <summary>
        /// Tests the <see cref="ExportableResult"/> constructor with null arguments.
        /// </summary>
        [Fact]
        public void ExportableResult_Null_2()
        {
            FileInfo fileInfo = new (Constants.Data.ExpectedHashFilePath);

            ExportableResult Constructor() => new (fileInfo, null);

            Assert.Throws<ArgumentNullException>(Constructor);
        }

        /// <summary>
        /// Tests the <see cref="ExportableResult"/> constructor with null arguments.
        /// </summary>
        [Fact]
        public void ExportableResult_Null_3()
        {
            FileInfo fileInfo = new (Constants.Data.ExpectedHashFilePath);

            ICollection<HashResult> hashResults = Models.GetHashResults(fileInfo);

            ExportableResult Constructor() => new (null, hashResults);

            Assert.Throws<ArgumentNullException>(Constructor);
        }

        /// <summary>
        /// Tests the <see cref="ExportableResult"/> constructor with valid arguments.
        /// </summary>
        [Fact]
        public void ExportableResult_Valid()
        {
            FileInfo fileInfo = new (Constants.Data.ExpectedHashFilePath);

            ICollection<HashResult> hashResults = Models.GetHashResults(fileInfo);

            ExportableResult exportableResult = new (fileInfo, hashResults);

            Assert.NotNull(exportableResult);
            Assert.NotNull(exportableResult.Filename);
            Assert.NotNull(exportableResult.Hashes);
            Assert.NotEmpty(exportableResult.Filename);
            Assert.NotEmpty(exportableResult.Hashes);
        }

        #endregion
    }
}