using Xunit;

namespace Hashx.Library.Tests;

/// <summary>
/// Defines unit tests for <see cref="SpanExtensions"/>.
/// </summary>
public sealed class SpanExtensionsTests
{
    /// <summary>
    /// Tests that <see cref="SpanExtensions.ToHexString(Span{byte})"/> returns the expected hexadecimal string.
    /// </summary>
    [Fact]
    public void SpanExtensions_ToHexString_Expected()
    {
        const string expected = "00010203";

        string actual = Input.Bytes.ToHexString();

        Assert.Equal(expected, actual);
    }
}
