namespace Hashx.Library.Tests;

using FluentAssertions;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="Xxh32Service"/>.
/// </summary>
public sealed class Xxh32ServiceTests
{
    /// <summary>
    /// Tests that <see cref="NonCryptographicHashingService.GetHash(FileInfo)"/> returns the
    /// expected <see cref="HashingResult"/>.
    /// </summary>
    [Fact]
    public void Xxh32Service_GetHash_Expected()
    {
        Xxh32Service service = new();

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        result.Algorithm.Should().Be(HashingAlgorithm.XXH32);
        result.Value.Should().Be(Hashes.XXH32);
    }
}