namespace Hashx.Library.Tests;

using System.Security.Cryptography;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="CryptographicHashingService"/>.
/// </summary>
public sealed class CryptographicHashingServiceTests
{
    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHashAndReset()"/> returns the expected MD5 result.
    /// </summary>
    [Fact]
    public void CryptographicHashingService_GetHashAndReset_MD5()
    {
        using CryptographicHashingService service = new(HashingAlgorithm.MD5, IncrementalHash.CreateHash(HashAlgorithmName.MD5));

        service.Append(Input.Bytes);

        HashingResult result = service.GetHashAndReset();

        Assert.Equal(HashingAlgorithm.MD5, result.Algorithm);
        Assert.Equal(Hashes.MD5, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHashAndReset()"/> returns the expected SHA1 result.
    /// </summary>
    [Fact]
    public void CryptographicHashingService_GetHashAndReset_SHA1()
    {
        using CryptographicHashingService service = new(HashingAlgorithm.SHA1, IncrementalHash.CreateHash(HashAlgorithmName.SHA1));

        service.Append(Input.Bytes);

        HashingResult result = service.GetHashAndReset();

        Assert.Equal(HashingAlgorithm.SHA1, result.Algorithm);
        Assert.Equal(Hashes.SHA1, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHashAndReset()"/> returns the expected SHA256 result.
    /// </summary>
    [Fact]
    public void CryptographicHashingService_GetHashAndReset_SHA256()
    {
        using CryptographicHashingService service = new(HashingAlgorithm.SHA256, IncrementalHash.CreateHash(HashAlgorithmName.SHA256));

        service.Append(Input.Bytes);

        HashingResult result = service.GetHashAndReset();

        Assert.Equal(HashingAlgorithm.SHA256, result.Algorithm);
        Assert.Equal(Hashes.SHA256, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHashAndReset()"/> returns the expected SHA3-256 result.
    /// </summary>
    [Fact]
    public void CryptographicHashingService_GetHashAndReset_SHA3_256()
    {
        using CryptographicHashingService service = new(HashingAlgorithm.SHA3_256, IncrementalHash.CreateHash(HashAlgorithmName.SHA3_256));

        service.Append(Input.Bytes);

        HashingResult result = service.GetHashAndReset();

        Assert.Equal(HashingAlgorithm.SHA3_256, result.Algorithm);
        Assert.Equal(Hashes.SHA3_256, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHashAndReset()"/> returns the expected SHA3-384 result.
    /// </summary>
    [Fact]
    public void CryptographicHashingService_GetHashAndReset_SHA3_384()
    {
        using CryptographicHashingService service = new(HashingAlgorithm.SHA3_384, IncrementalHash.CreateHash(HashAlgorithmName.SHA3_384));

        service.Append(Input.Bytes);

        HashingResult result = service.GetHashAndReset();

        Assert.Equal(HashingAlgorithm.SHA3_384, result.Algorithm);
        Assert.Equal(Hashes.SHA3_384, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHashAndReset()"/> returns the expected SHA3-512 result.
    /// </summary>
    [Fact]
    public void CryptographicHashingService_GetHashAndReset_SHA3_512()
    {
        using CryptographicHashingService service = new(HashingAlgorithm.SHA3_512, IncrementalHash.CreateHash(HashAlgorithmName.SHA3_512));

        service.Append(Input.Bytes);

        HashingResult result = service.GetHashAndReset();

        Assert.Equal(HashingAlgorithm.SHA3_512, result.Algorithm);
        Assert.Equal(Hashes.SHA3_512, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHashAndReset()"/> returns the expected SHA384 result.
    /// </summary>
    [Fact]
    public void CryptographicHashingService_GetHashAndReset_SHA384()
    {
        using CryptographicHashingService service = new(HashingAlgorithm.SHA384, IncrementalHash.CreateHash(HashAlgorithmName.SHA384));

        service.Append(Input.Bytes);

        HashingResult result = service.GetHashAndReset();

        Assert.Equal(HashingAlgorithm.SHA384, result.Algorithm);
        Assert.Equal(Hashes.SHA384, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHashAndReset()"/> returns the expected SHA512 result.
    /// </summary>
    [Fact]
    public void CryptographicHashingService_GetHashAndReset_SHA512()
    {
        using CryptographicHashingService service = new(HashingAlgorithm.SHA512, IncrementalHash.CreateHash(HashAlgorithmName.SHA512));

        service.Append(Input.Bytes);

        HashingResult result = service.GetHashAndReset();

        Assert.Equal(HashingAlgorithm.SHA512, result.Algorithm);
        Assert.Equal(Hashes.SHA512, result.Value);
    }
}