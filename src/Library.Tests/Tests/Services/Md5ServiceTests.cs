namespace Hashx.Library.Tests;

using Xunit;

/// <summary>
/// Defines unit tests for <see cref="Md5Service"/>.
/// </summary>
public sealed class Md5ServiceTests
{
    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHash(FileInfo)"/> returns the expected
    /// <see cref="HashingResult"/>.
    /// </summary>
    [Fact]
    public void Md5Service_GetHash_Expected()
    {
        Md5Service service = new();

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        Assert.Equal(HashingAlgorithm.MD5, result.Algorithm);
        Assert.Equal(Hashes.MD5, result.Value);
    }
}