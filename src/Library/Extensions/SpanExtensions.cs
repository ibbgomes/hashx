namespace Hashx.Library;

/// <summary>
/// Defines extension methods for <see cref="Span{T}"/>.
/// </summary>
internal static class SpanExtensions
{
    /// <summary>
    /// Converts this <see cref="byte"/> span to a lowercase hexadecimal <see cref="string"/>.
    /// </summary>
    /// <param name="bytes">The byte span.</param>
    /// <returns>The hexadecimal string.</returns>
    internal static string ToHexString(this Span<byte> bytes) => Convert.ToHexStringLower(bytes);
}
