namespace Hashx.Library.Tests;

using Xunit;

/// <summary>
/// Defines unit tests for <see cref="Sha256Service"/>.
/// </summary>
public sealed class Sha256ServiceTests
{
    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHash(FileInfo)"/> returns the expected
    /// <see cref="HashingResult"/>.
    /// </summary>
    [Fact]
    public void Sha256Service_GetHash_Expected()
    {
        Sha256Service service = new();

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        Assert.Equal(HashingAlgorithm.SHA256, result.Algorithm);
        Assert.Equal(Hashes.SHA256, result.Value);
    }
}