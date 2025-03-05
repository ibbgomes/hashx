namespace Hashx.Library.Tests;

using FluentAssertions;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="Md5Service"/>.
/// </summary>
public sealed class Md5ServiceTests
{
    #region Public Methods

    /// <summary>
    /// Tests that <see cref="HashingService.GetHash(FileInfo)"/> returns the expected <see cref="HashingResult"/>.
    /// </summary>
    [Fact]
    public void Md5Service_GetHash_Expected()
    {
        Md5Service service = new();

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        result.Algorithm.Should().Be(HashingAlgorithm.MD5);
        result.Value.Should().Be(Hashes.MD5);
    }

    #endregion
}