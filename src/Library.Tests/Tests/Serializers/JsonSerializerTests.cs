namespace Hashx.Library.Tests;

using System.Diagnostics.CodeAnalysis;
using System.IO;
using FluentAssertions;
using Hashx.Library;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="JsonSerializer"/>.
/// </summary>
[SuppressMessage("Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Unit tests.")]
public sealed class JsonSerializerTests
{
    #region Public Methods

    /// <summary>
    /// Tests the <see cref="JsonSerializer.Serialize(object)"/> method with valid arguments.
    /// </summary>
    [Fact]
    public void JsonSerializer_Serialize_Valid()
    {
        FileInfo fileInfo = new(Data.MockFilePath);

        ExportableResult result = Serialization.GetExportableResult(fileInfo);

        string expected = File.ReadAllText(Data.JsonResultFilePath);

        string actual = JsonSerializer.Serialize(result);

        actual.Should().Be(expected);
    }

    #endregion
}