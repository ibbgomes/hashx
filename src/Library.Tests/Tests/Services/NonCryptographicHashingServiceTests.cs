namespace Hashx.Library.Tests;

using System.IO.Hashing;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="NonCryptographicHashingService"/>.
/// </summary>
public sealed class NonCryptographicHashingServiceTests
{
    /// <summary>
    /// Tests that <see cref="NonCryptographicHashingService.GetHashAndReset()"/> returns the expected CRC32 result.
    /// </summary>
    [Fact]
    public void NonCryptographicHashingService_GetHashAndReset_CRC32()
    {
        using NonCryptographicHashingService service = new(HashingAlgorithm.CRC32, new Crc32());

        service.Append(Input.Bytes);

        HashingResult result = service.GetHashAndReset();

        Assert.Equal(HashingAlgorithm.CRC32, result.Algorithm);
        Assert.Equal(Hashes.CRC32, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="NonCryptographicHashingService.GetHashAndReset()"/> returns the expected CRC64 result.
    /// </summary>
    [Fact]
    public void NonCryptographicHashingService_GetHashAndReset_CRC64()
    {
        using NonCryptographicHashingService service = new(HashingAlgorithm.CRC64, new Crc64());

        service.Append(Input.Bytes);

        HashingResult result = service.GetHashAndReset();

        Assert.Equal(HashingAlgorithm.CRC64, result.Algorithm);
        Assert.Equal(Hashes.CRC64, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="NonCryptographicHashingService.GetHashAndReset()"/> returns the expected XXH128 result.
    /// </summary>
    [Fact]
    public void NonCryptographicHashingService_GetHashAndReset_XXH128()
    {
        using NonCryptographicHashingService service = new(HashingAlgorithm.XXH128, new XxHash128());

        service.Append(Input.Bytes);

        HashingResult result = service.GetHashAndReset();

        Assert.Equal(HashingAlgorithm.XXH128, result.Algorithm);
        Assert.Equal(Hashes.XXH128, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="NonCryptographicHashingService.GetHashAndReset()"/> returns the expected XXH3 result.
    /// </summary>
    [Fact]
    public void NonCryptographicHashingService_GetHashAndReset_XXH3()
    {
        using NonCryptographicHashingService service = new(HashingAlgorithm.XXH3, new XxHash3());

        service.Append(Input.Bytes);

        HashingResult result = service.GetHashAndReset();

        Assert.Equal(HashingAlgorithm.XXH3, result.Algorithm);
        Assert.Equal(Hashes.XXH3, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="NonCryptographicHashingService.GetHashAndReset()"/> returns the expected XXH32 result.
    /// </summary>
    [Fact]
    public void NonCryptographicHashingService_GetHashAndReset_XXH32()
    {
        using NonCryptographicHashingService service = new(HashingAlgorithm.XXH32, new XxHash32());

        service.Append(Input.Bytes);

        HashingResult result = service.GetHashAndReset();

        Assert.Equal(HashingAlgorithm.XXH32, result.Algorithm);
        Assert.Equal(Hashes.XXH32, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="NonCryptographicHashingService.GetHashAndReset()"/> returns the expected XXH64 result.
    /// </summary>
    [Fact]
    public void NonCryptographicHashingService_GetHashAndReset_XXH64()
    {
        using NonCryptographicHashingService service = new(HashingAlgorithm.XXH64, new XxHash64());

        service.Append(Input.Bytes);

        HashingResult result = service.GetHashAndReset();

        Assert.Equal(HashingAlgorithm.XXH64, result.Algorithm);
        Assert.Equal(Hashes.XXH64, result.Value);
    }
}