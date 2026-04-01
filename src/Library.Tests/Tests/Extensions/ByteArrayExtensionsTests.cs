namespace Hashx.Library.Tests;

using Hashx.Library;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="ByteArrayExtensions"/>.
/// </summary>
public sealed class ByteArrayExtensionsTests
{
    /// <summary>
    /// Tests that <see cref="ByteArrayExtensions.ToHexString(byte[])"/> returns the expected hexadecimal string.
    /// </summary>
    [Fact]
    public void ByteArrayExtensions_ToHexString_Expected()
    {
        const string expected = "00010203";

        string actual = Input.Bytes.ToHexString();

        Assert.Equal(expected, actual);
    }
}