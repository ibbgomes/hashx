namespace Hashx.Library.Tests;

using FluentAssertions;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="Crc32Service"/>.
/// </summary>
public sealed class Crc32ServiceTests
{
    /// <summary>
    /// Tests that <see cref="NonCryptographicHashingService.GetHash(FileInfo)"/> returns the
    /// expected <see cref="HashingResult"/>.
    /// </summary>
    [Fact]
    public void Crc32Service_GetHash_Expected()
    {
        Crc32Service service = new();

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        result.Algorithm.Should().Be(HashingAlgorithm.CRC32);
        result.Value.Should().Be(Hashes.CRC32);
    }
}