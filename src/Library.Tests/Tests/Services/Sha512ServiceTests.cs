namespace Hashx.Library.Tests;

using Xunit;

/// <summary>
/// Defines unit tests for <see cref="Sha512Service"/>.
/// </summary>
public sealed class Sha512ServiceTests
{
    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHash(FileInfo)"/> returns the expected
    /// <see cref="HashingResult"/>.
    /// </summary>
    [Fact]
    public void Sha512Service_GetHash_Expected()
    {
        Sha512Service service = new();

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        Assert.Equal(HashingAlgorithm.SHA512, result.Algorithm);
        Assert.Equal(Hashes.SHA512, result.Value);
    }
}