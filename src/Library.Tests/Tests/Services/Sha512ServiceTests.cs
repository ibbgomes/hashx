namespace Hashx.Library.Tests;

using System.Diagnostics.CodeAnalysis;
using System.IO;
using FluentAssertions;
using Hashx.Library;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="Sha512Service"/>.
/// </summary>
[SuppressMessage("Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Unit tests.")]
public sealed class Sha512ServiceTests
{
    #region Public Methods

    /// <summary>
    /// Tests that <see cref="HashingService.GetHash(FileInfo)"/> returns the expected <see cref="HashingResult"/>.
    /// </summary>
    [Fact]
    public void Sha512Service_GetHash_Expected()
    {
        IHashingService service = new Sha512Service();

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        result.Algorithm.Should().Be(HashingAlgorithm.SHA512);
        result.Value.Should().Be(Hashes.SHA512);
    }

    #endregion
}