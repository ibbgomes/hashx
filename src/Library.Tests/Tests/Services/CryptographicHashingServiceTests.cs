namespace Hashx.Library.Tests;

using System.Security.Cryptography;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="CryptographicHashingService"/>.
/// </summary>
public sealed class CryptographicHashingServiceTests
{
    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHash(FileInfo)"/> returns the expected MD5 result.
    /// </summary>
    [Fact]
    public void CryptographicHashingService_GetHash_MD5()
    {
        CryptographicHashingService service = new(HashingAlgorithm.MD5, MD5.Create());

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        Assert.Equal(HashingAlgorithm.MD5, result.Algorithm);
        Assert.Equal(Hashes.MD5, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHash(FileInfo)"/> returns the expected SHA1 result.
    /// </summary>
    [Fact]
    public void CryptographicHashingService_GetHash_SHA1()
    {
        CryptographicHashingService service = new(HashingAlgorithm.SHA1, SHA1.Create());

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        Assert.Equal(HashingAlgorithm.SHA1, result.Algorithm);
        Assert.Equal(Hashes.SHA1, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHash(FileInfo)"/> returns the expected SHA256 result.
    /// </summary>
    [Fact]
    public void CryptographicHashingService_GetHash_SHA256()
    {
        CryptographicHashingService service = new(HashingAlgorithm.SHA256, SHA256.Create());

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        Assert.Equal(HashingAlgorithm.SHA256, result.Algorithm);
        Assert.Equal(Hashes.SHA256, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHash(FileInfo)"/> returns the expected SHA3-256 result.
    /// </summary>
    [Fact]
    public void CryptographicHashingService_GetHash_SHA3_256()
    {
        CryptographicHashingService service = new(HashingAlgorithm.SHA3_256, SHA3_256.Create());

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        Assert.Equal(HashingAlgorithm.SHA3_256, result.Algorithm);
        Assert.Equal(Hashes.SHA3_256, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHash(FileInfo)"/> returns the expected SHA3-384 result.
    /// </summary>
    [Fact]
    public void CryptographicHashingService_GetHash_SHA3_384()
    {
        CryptographicHashingService service = new(HashingAlgorithm.SHA3_384, SHA3_384.Create());

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        Assert.Equal(HashingAlgorithm.SHA3_384, result.Algorithm);
        Assert.Equal(Hashes.SHA3_384, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHash(FileInfo)"/> returns the expected SHA3-512 result.
    /// </summary>
    [Fact]
    public void CryptographicHashingService_GetHash_SHA3_512()
    {
        CryptographicHashingService service = new(HashingAlgorithm.SHA3_512, SHA3_512.Create());

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        Assert.Equal(HashingAlgorithm.SHA3_512, result.Algorithm);
        Assert.Equal(Hashes.SHA3_512, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHash(FileInfo)"/> returns the expected SHA384 result.
    /// </summary>
    [Fact]
    public void CryptographicHashingService_GetHash_SHA384()
    {
        CryptographicHashingService service = new(HashingAlgorithm.SHA384, SHA384.Create());

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        Assert.Equal(HashingAlgorithm.SHA384, result.Algorithm);
        Assert.Equal(Hashes.SHA384, result.Value);
    }

    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHash(FileInfo)"/> returns the expected SHA512 result.
    /// </summary>
    [Fact]
    public void CryptographicHashingService_GetHash_SHA512()
    {
        CryptographicHashingService service = new(HashingAlgorithm.SHA512, SHA512.Create());

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        Assert.Equal(HashingAlgorithm.SHA512, result.Algorithm);
        Assert.Equal(Hashes.SHA512, result.Value);
    }
}