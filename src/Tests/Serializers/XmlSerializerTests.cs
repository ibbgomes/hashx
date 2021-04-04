namespace Hashx.Tests.Serializers
{
    using System;
    using System.IO;
    using Hashx.Library.Models;
    using Hashx.Library.Serializers;
    using Hashx.Tests.Common;
    using Xunit;

    /// <summary>
    /// Defines unit tests related with the <see cref="XmlSerializer"/> type.
    /// </summary>
    [Collection(nameof(Library))]
    public sealed class XmlSerializerTests
    {
        #region Public Methods

        /// <summary>
        /// Tests the <see cref="XmlSerializer.Serialize(ExportableResult)"/> method with null arguments.
        /// </summary>
        [Fact]
        public void XmlSerializer_Serialize_Null()
        {
            static string Serialize() => XmlSerializer.Serialize(null);

            Assert.Throws<ArgumentNullException>(Serialize);
        }

        /// <summary>
        /// Tests the <see cref="XmlSerializer.Serialize(ExportableResult)"/> method with valid arguments.
        /// </summary>
        [Fact]
        public void XmlSerializer_Serialize_Valid()
        {
            FileInfo fileInfo = new (Constants.Data.ExpectedHashFilePath);

            ExportableResult result = Models.GetExportableResult(fileInfo);

            string expected = File.ReadAllText(Constants.Data.XmlExportFilePath);

            string actual = XmlSerializer.Serialize(result);

            Assert.Equal(expected, actual);
        }

        #endregion
    }
}