namespace Hashx.Library.Tests;

using System.Diagnostics.CodeAnalysis;
using System.IO;
using FluentAssertions;
using Hashx.Library;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="Sha384Service"/>.
/// </summary>
[SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit tests.")]
public sealed class Sha384ServiceTests
{
    #region Public Methods

    /// <summary>
    /// Tests that <see cref="HashingService.GetHash(FileInfo)"/> returns the expected <see cref="HashingResult"/>.
    /// </summary>
    [Fact]
    public void Sha384Service_GetHash_Expected()
    {
        IHashingService service = new Sha384Service();

        FileInfo fileInfo = new(Data.MockFilePath);

        HashingResult result = service.GetHash(fileInfo);

        result.Algorithm.Should().Be(HashingAlgorithm.SHA384);
        result.Value.Should().Be(Hashes.SHA384);
    }

    #endregion
}