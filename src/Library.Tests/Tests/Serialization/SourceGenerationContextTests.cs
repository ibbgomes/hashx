namespace Hashx.Library.Tests;

using System.Text.Json;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="SourceGenerationContext"/>.
/// </summary>
public sealed class SourceGenerationContextTests
{
    /// <summary>
    /// Tests that using <see cref="SourceGenerationContext"/> to serialize <see cref="ExportableResult"/> produces the expected JSON string.
    /// </summary>
    [Fact]
    public void SourceGenerationContext_ExportableResult_Expected()
    {
        FileInfo fileInfo = new(Data.InputFilePath);

        HashingResult[] results =
        [
            new(HashingAlgorithm.XXH3, Hashes.XXH3),
        ];

        ExportableResult exportableResult = new(fileInfo, results);

        string actual = JsonSerializer.Serialize(exportableResult, SourceGenerationContext.Default.ExportableResult);

        const string expected = $$"""
            {
              "filename": "mock.json",
              "hashes": {
                "xxh3": "{{Hashes.XXH3}}"
              }
            }
            """;

        Assert.Equal(expected, actual);
    }
}