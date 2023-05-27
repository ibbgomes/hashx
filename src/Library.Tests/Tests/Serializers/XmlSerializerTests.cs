namespace Hashx.Library.Tests;

using System.Diagnostics.CodeAnalysis;
using System.IO;
using FluentAssertions;
using Hashx.Library;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="XmlSerializer"/>.
/// </summary>
[SuppressMessage("Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Unit tests.")]
public sealed class XmlSerializerTests
{
    #region Public Methods

    /// <summary>
    /// Tests the <see cref="XmlSerializer.Serialize(object)"/> method with valid arguments.
    /// </summary>
    [Fact]
    public void XmlSerializer_Serialize_Valid()
    {
        FileInfo fileInfo = new(Data.MockFilePath);

        ExportableResult result = Serialization.GetExportableResult(fileInfo);

        string expected = File.ReadAllText(Data.XmlResultFilePath);

        string actual = XmlSerializer.Serialize(result);

        actual.Should().Be(expected);
    }

    #endregion
}