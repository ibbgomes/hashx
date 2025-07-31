namespace Hashx.Library.Tests;

using FluentAssertions;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="Crc64Service"/>.
/// </summary>
public sealed class Crc64ServiceTests
{
    /// <summary>
    /// Tests that <see cref="NonCryptographicHashingService.GetHash(FileInfo)"/> returns the
    /// expected <see cref="HashingResult"/>.
    /// </summary>
    [Fact]
    public void Crc64Service_GetHash_Expected()
    {
        Crc64Service service = new();

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        result.Algorithm.Should().Be(HashingAlgorithm.CRC64);
        result.Value.Should().Be(Hashes.CRC64);
    }
}