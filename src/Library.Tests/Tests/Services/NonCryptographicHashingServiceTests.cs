namespace Hashx.Library.Tests;

using System.IO.Hashing;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="NonCryptographicHashingService"/>.
/// </summary>
public sealed class NonCryptographicHashingServiceTests
{
    /// <summary>
    /// Tests that <see cref="NonCryptographicHashingService.GetHash(FileInfo)"/> returns the expected CRC32 result.
    /// </summary>
    [Fact]
    public void NonCryptographicHashingService_GetHash_CRC32()
    {
        NonCryptographicHashingService service = new(HashingAlgorithm.CRC32, new Crc32());

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        Assert.Equal(HashingAlgorithm.CRC32, result.Algorithm);
        Assert.Equal(Hashes.CRC32, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="NonCryptographicHashingService.GetHash(FileInfo)"/> returns the expected CRC64 result.
    /// </summary>
    [Fact]
    public void NonCryptographicHashingService_GetHash_CRC64()
    {
        NonCryptographicHashingService service = new(HashingAlgorithm.CRC64, new Crc64());

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        Assert.Equal(HashingAlgorithm.CRC64, result.Algorithm);
        Assert.Equal(Hashes.CRC64, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="NonCryptographicHashingService.GetHash(FileInfo)"/> returns the expected XXH128 result.
    /// </summary>
    [Fact]
    public void NonCryptographicHashingService_GetHash_XXH128()
    {
        NonCryptographicHashingService service = new(HashingAlgorithm.XXH128, new XxHash128());

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        Assert.Equal(HashingAlgorithm.XXH128, result.Algorithm);
        Assert.Equal(Hashes.XXH128, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="NonCryptographicHashingService.GetHash(FileInfo)"/> returns the expected XXH3 result.
    /// </summary>
    [Fact]
    public void NonCryptographicHashingService_GetHash_XXH3()
    {
        NonCryptographicHashingService service = new(HashingAlgorithm.XXH3, new XxHash3());

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        Assert.Equal(HashingAlgorithm.XXH3, result.Algorithm);
        Assert.Equal(Hashes.XXH3, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="NonCryptographicHashingService.GetHash(FileInfo)"/> returns the expected XXH32 result.
    /// </summary>
    [Fact]
    public void NonCryptographicHashingService_GetHash_XXH32()
    {
        NonCryptographicHashingService service = new(HashingAlgorithm.XXH32, new XxHash32());

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        Assert.Equal(HashingAlgorithm.XXH32, result.Algorithm);
        Assert.Equal(Hashes.XXH32, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="NonCryptographicHashingService.GetHash(FileInfo)"/> returns the expected XXH64 result.
    /// </summary>
    [Fact]
    public void NonCryptographicHashingService_GetHash_XXH64()
    {
        NonCryptographicHashingService service = new(HashingAlgorithm.XXH64, new XxHash64());

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        Assert.Equal(HashingAlgorithm.XXH64, result.Algorithm);
        Assert.Equal(Hashes.XXH64, result.Value);
    }
}