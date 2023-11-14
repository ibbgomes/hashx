namespace Hashx.Library;

using System;

/// <summary>
/// Provides extension methods for <see cref="byte"/> arrays.
/// </summary>
internal static class ByteArrayExtensions
{
    #region Internal Methods

    /// <summary>
    /// Converts this <see cref="byte"/> array to a hexadecimal <see cref="string"/>.
    /// </summary>
    /// <param name="bytes">The byte array.</param>
    /// <returns>The hexadecimal string.</returns>
    internal static string ToHexString(this byte[] bytes)
    {
        return BitConverter
            .ToString(bytes)
            .Replace("-", string.Empty, StringComparison.OrdinalIgnoreCase)
            .ToUpperInvariant();
    }

    #endregion
}