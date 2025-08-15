namespace Hashx.Library.Tests;

using FluentAssertions;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="Xxh128Service"/>.
/// </summary>
public sealed class Xxh128ServiceTests
{
    /// <summary>
    /// Tests that <see cref="NonCryptographicHashingService.GetHash(FileInfo)"/> returns the
    /// expected <see cref="HashingResult"/>.
    /// </summary>
    [Fact]
    public void Xxh128Service_GetHash_Expected()
    {
        Xxh128Service service = new();

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        result.Algorithm.Should().Be(HashingAlgorithm.XXH128);
        result.Value.Should().Be(Hashes.XXH128);
    }
}