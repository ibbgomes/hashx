namespace Hashx.Application.Tests;

using System.Text.Encodings.Web;
using System.Text.Json;
using Hashx.Library;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="SourceGenerationContext"/>.
/// </summary>
public sealed class SourceGenerationContextTests
{
    private static readonly JsonSerializerOptions serializerOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    private static readonly SourceGenerationContext serializerContext = new(serializerOptions);

    /// <summary>
    /// Tests that using <see cref="SourceGenerationContext"/> to serialize <see cref="HashingReport"/> produces the expected JSON string.
    /// </summary>
    [Fact]
    public void SourceGenerationContext_HashingReport_Expected()
    {
        FileInfo file = new("r&d.json");

        HashingResult[] results =
        [
            new(HashingAlgorithm.XXH3, Hashes.XXH3),
        ];

        HashingReport report = new(file, results);

        string actual = JsonSerializer.Serialize(report, serializerContext.HashingReport);

        const string expected = $$"""
            {
              "source": "r&d.json",
              "hashes": {
                "xxh3": "{{Hashes.XXH3}}"
              }
            }
            """;

        Assert.Equal(expected, actual);
    }
}