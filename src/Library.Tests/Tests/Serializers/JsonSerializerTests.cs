namespace Hashx.Library.Tests;

using System.Collections.Generic;
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

        List<HashingResult> results = new()
        {
            new(HashingAlgorithm.MD5, Hashes.MD5),
            new(HashingAlgorithm.SHA1, Hashes.SHA1),
            new(HashingAlgorithm.SHA256, Hashes.SHA256),
            new(HashingAlgorithm.SHA384, Hashes.SHA384),
            new(HashingAlgorithm.SHA512, Hashes.SHA512),
        };

        ExportableResult exportableResult = new(fileInfo, results);

        string actual = JsonSerializer.Serialize(exportableResult);

        string expected = File.ReadAllText(Data.JsonResultFilePath);

        actual.Should().Be(expected);
    }

    #endregion
}