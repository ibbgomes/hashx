namespace Hashx.Library.Tests;

using System.Diagnostics.CodeAnalysis;
using System.IO;
using FluentAssertions;
using Hashx.Library;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="Sha256Service"/>.
/// </summary>
[SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit tests.")]
public sealed class Sha256ServiceTests
{
    #region Public Methods

    /// <summary>
    /// Tests that <see cref="HashingService.GetHash(FileInfo)"/> returns the expected <see cref="HashingResult"/>.
    /// </summary>
    [Fact]
    public void Sha256Service_GetHash_Expected()
    {
        IHashingService service = new Sha256Service();

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        result.Algorithm.Should().Be(HashingAlgorithm.SHA256);
        result.Value.Should().Be(Hashes.SHA256);
    }

    #endregion
}