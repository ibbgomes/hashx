namespace Hashx.Library.Tests;

using FluentAssertions;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="Xxh64Service"/>.
/// </summary>
public sealed class Xxh64ServiceTests
{
    /// <summary>
    /// Tests that <see cref="NonCryptographicHashingService.GetHash(FileInfo)"/> returns the
    /// expected <see cref="HashingResult"/>.
    /// </summary>
    [Fact]
    public void Xxh64Service_GetHash_Expected()
    {
        Xxh64Service service = new();

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        result.Algorithm.Should().Be(HashingAlgorithm.XXH64);
        result.Value.Should().Be(Hashes.XXH64);
    }
}