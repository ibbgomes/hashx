namespace Hashx.Library.Tests;

using Xunit;

/// <summary>
/// Defines unit tests for <see cref="JsonSerializer"/>.
/// </summary>
public sealed class JsonSerializerTests
{
    /// <summary>
    /// Tests the <see cref="JsonSerializer.Serialize(object)"/> returns the expected <see cref="string"/>.
    /// </summary>
    [Fact]
    public void JsonSerializer_Serialize_Expected()
    {
        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult[] results =
        [
            new(HashingAlgorithm.XXH3, Hashes.XXH3),
        ];

        ExportableResult exportableResult = new(fileInfo, results);

        string actual = JsonSerializer.Serialize(exportableResult);

        const string expected = """
            {
              "filename": "mock.json",
              "hashes": {
                "xxh3": "bded7fd1ae43547e"
              }
            }
            """;

        Assert.Equal(expected, actual);
    }
}