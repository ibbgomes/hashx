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
            new(HashingAlgorithm.CRC32, Hashes.CRC32),
            new(HashingAlgorithm.CRC64, Hashes.CRC64),
            new(HashingAlgorithm.MD5, Hashes.MD5),
            new(HashingAlgorithm.SHA1, Hashes.SHA1),
            new(HashingAlgorithm.SHA256, Hashes.SHA256),
            new(HashingAlgorithm.SHA384, Hashes.SHA384),
            new(HashingAlgorithm.SHA512, Hashes.SHA512),
            new(HashingAlgorithm.XXH128, Hashes.XXH128),
            new(HashingAlgorithm.XXH3, Hashes.XXH3),
            new(HashingAlgorithm.XXH32, Hashes.XXH32),
            new(HashingAlgorithm.XXH64, Hashes.XXH64),
        ];

        ExportableResult exportableResult = new(fileInfo, results);

        string actual = JsonSerializer.Serialize(exportableResult);

        string expected = File.ReadAllText(Data.JsonResultFilePath);

        Assert.Equal(expected, actual);
    }
}