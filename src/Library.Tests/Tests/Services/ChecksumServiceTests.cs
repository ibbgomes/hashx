namespace Hashx.Library.Tests;

using Xunit;

/// <summary>
/// Defines unit tests for <see cref="ChecksumService"/>.
/// </summary>
public sealed class ChecksumServiceTests
{
    /// <summary>
    /// Tests that <see cref="ChecksumService.GetChecksums(Stream, IEnumerable{HashingAlgorithm})"/> returns the expected result.
    /// </summary>
    [Fact]
    public void ChecksumService_GetChecksums_Expected()
    {
        ChecksumService service = new();

        using MemoryStream stream = new(Input.Bytes);

        HashingResult result = service.GetChecksums(stream, HashingAlgorithm.XXH3).First();

        Assert.Equal(HashingAlgorithm.XXH3, result.Algorithm);
        Assert.Equal(Hashes.XXH3, result.Value);
    }
}