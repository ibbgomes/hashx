namespace Hashx.Application.Tests;

using System.Text.Json;
using Hashx.Library;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="SourceGenerationContext"/>.
/// </summary>
public sealed class SourceGenerationContextTests
{
    /// <summary>
    /// Tests that using <see cref="SourceGenerationContext"/> to serialize <see cref="ChecksumReport"/> produces the expected JSON string.
    /// </summary>
    [Fact]
    public void SourceGenerationContext_ChecksumReport_Expected()
    {
        FileInfo file = new("dummy.json");

        HashingResult[] results =
        [
            new(HashingAlgorithm.XXH3, Hashes.XXH3),
        ];

        ChecksumReport report = new(file, results);

        string actual = JsonSerializer.Serialize(report, SourceGenerationContext.Default.ChecksumReport);

        const string expected = $$"""
            {
              "source": "dummy.json",
              "hashes": {
                "xxh3": "{{Hashes.XXH3}}"
              }
            }
            """;

        Assert.Equal(expected, actual);
    }
}