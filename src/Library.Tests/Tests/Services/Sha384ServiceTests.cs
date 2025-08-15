namespace Hashx.Library.Tests;

using Xunit;

/// <summary>
/// Defines unit tests for <see cref="Sha384Service"/>.
/// </summary>
public sealed class Sha384ServiceTests
{
    /// <summary>
    /// Tests that <see cref="CryptographicHashingService.GetHash(FileInfo)"/> returns the expected
    /// <see cref="HashingResult"/>.
    /// </summary>
    [Fact]
    public void Sha384Service_GetHash_Expected()
    {
        Sha384Service service = new();

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        Assert.Equal(HashingAlgorithm.SHA384, result.Algorithm);
        Assert.Equal(Hashes.SHA384, result.Value);
    }
}