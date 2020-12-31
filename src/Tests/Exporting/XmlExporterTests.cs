namespace Hashx.Tests.Exporting
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using Hashx.Library.Contracts;
    using Hashx.Library.Exporting;
    using Hashx.Library.Hashing;
    using Hashx.Library.Models;
    using Xunit;

    /// <summary>
    /// Defines unit tests related with the <see cref="XmlExporter"/> type.
    /// </summary>
    [Collection(nameof(Library))]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Unit test.")]
    public sealed class XmlExporterTests
    {
        #region Public Methods

        /// <summary>
        /// Tests the <see cref="XmlExporter.Serialize(ExportableResult)"/> method with null arguments.
        /// </summary>
        [Fact]
        public void XmlExporter_Serialize_Null()
        {
            static string Serialize() => XmlExporter.Serialize(null);

            Assert.Throws<ArgumentNullException>(Serialize);
        }

        /// <summary>
        /// Tests the <see cref="XmlExporter.Serialize(ExportableResult)"/> method with valid arguments.
        /// </summary>
        [Fact]
        public void XmlExporter_Serialize_Valid()
        {
            string expected = File.ReadAllText(Constants.Data.XmlExportFilePath);

            string actual = XmlExporter.Serialize(GetResult());

            Assert.Equal(expected, actual);
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

        private static ExportableResult GetResult()
        {
            IEnumerable<IHash> hashAlgos = GetHashAlgos();

            ICollection<HashResult> results = new List<HashResult>();

            foreach (IHash hashAlgo in hashAlgos)
            {
                HashResult result = hashAlgo.GetHash(Constants.Data.ExpectedHashFilePath);

                results.Add(result);
            }

            FileInfo fileInfo = new FileInfo(Constants.Data.ExpectedHashFilePath);

            return new ExportableResult(fileInfo, results);
        }

        #endregion
    }
}