namespace Hashx.Library.Tests;

using FluentAssertions;
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

        result.Algorithm.Should().Be(HashingAlgorithm.SHA384);
        result.Value.Should().Be(Hashes.SHA384);
    }
}