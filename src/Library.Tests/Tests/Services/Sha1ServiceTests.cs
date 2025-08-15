namespace Hashx.Library.Tests;

using Xunit;

/// <summary>
/// Defines unit tests for <see cref="Sha1Service"/>.
/// </summary>
public sealed class Sha1ServiceTests
{
    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHash(FileInfo)"/> returns the expected
    /// <see cref="HashingResult"/>.
    /// </summary>
    [Fact]
    public void Sha1Service_GetHash_Expected()
    {
        Sha1Service service = new();

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        Assert.Equal(HashingAlgorithm.SHA1, result.Algorithm);
        Assert.Equal(Hashes.SHA1, result.Value);
    }
}