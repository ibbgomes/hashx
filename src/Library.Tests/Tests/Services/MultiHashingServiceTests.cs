using Xunit;

namespace Hashx.Library.Tests;

/// <summary>
/// Defines unit tests for <see cref="MultiHashingService"/>.
/// </summary>
public sealed class MultiHashingServiceTests
{
    /// <summary>
    /// Tests that <see cref="MultiHashingService.GetHashes(Stream, IEnumerable{HashingAlgorithm})"/> returns the expected result.
    /// </summary>
    [Fact]
    public void MultiHashingService_GetHashes_Expected()
    {
        MultiHashingService service = new();

        using MemoryStream stream = new(Input.Bytes);

        HashingResult result = service.GetHashes(stream, HashingAlgorithm.XXH3).First();

        Assert.Equal(HashingAlgorithm.XXH3, result.Algorithm);
        Assert.Equal(Hashes.XXH3, result.Hash);
    }
}