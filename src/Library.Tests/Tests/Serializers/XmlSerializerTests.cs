namespace Hashx.Library.Tests;

using FluentAssertions;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="XmlSerializer"/>.
/// </summary>
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

        List<HashingResult> results =
        [
            new(HashingAlgorithm.MD5, Hashes.MD5),
            new(HashingAlgorithm.SHA1, Hashes.SHA1),
            new(HashingAlgorithm.SHA256, Hashes.SHA256),
            new(HashingAlgorithm.SHA384, Hashes.SHA384),
            new(HashingAlgorithm.SHA512, Hashes.SHA512),
        ];

        ExportableResult exportableResult = new(fileInfo, results);

        string actual = XmlSerializer.Serialize(exportableResult);

        string expected = File.ReadAllText(Data.XmlResultFilePath);

        actual.Should().Be(expected);
    }

    #endregion
}