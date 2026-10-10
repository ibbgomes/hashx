using System.Security.Cryptography;

namespace Hashx.Library;

/// <summary>
/// Defines a cryptographic implementation of <see cref="IHashingService"/>.
/// </summary>
/// <seealso cref="IHashingService"/>
internal sealed class CryptographicHashingService(HashingAlgorithm algorithm, IncrementalHash implementation) : IHashingService
{
    /// <inheritdoc/>
    public HashingAlgorithm Algorithm => algorithm;

    /// <inheritdoc/>
    public void Append(ReadOnlySpan<byte> data) => implementation.AppendData(data);

    /// <inheritdoc/>
    public void Dispose() => implementation.Dispose();

    /// <inheritdoc/>
    public HashingResult GetHashAndReset()
    {
        Span<byte> digest = stackalloc byte[implementation.HashLengthInBytes];

        implementation.GetHashAndReset(digest);

        return new(this.Algorithm, digest.ToHexString());
    }
}
