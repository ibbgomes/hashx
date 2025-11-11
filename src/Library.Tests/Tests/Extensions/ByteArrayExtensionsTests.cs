namespace Hashx.Library.Tests;

using Xunit;
using Hashx.Library;

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
        byte[] bytes = [0x00, 0x01, 0x02, 0x03];

        const string expected = "00010203";

        string actual = bytes.ToHexString();

        Assert.Equal(expected, actual);
    }
}