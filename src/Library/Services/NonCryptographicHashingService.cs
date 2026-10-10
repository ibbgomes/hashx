using System.IO.Hashing;

namespace Hashx.Library;

/// <summary>
/// Defines a non-cryptographic implementation of <see cref="IHashingService"/>
/// </summary>
/// <seealso cref="IHashingService"/>
internal sealed class NonCryptographicHashingService(HashingAlgorithm algorithm, NonCryptographicHashAlgorithm implementation) : IHashingService
{
    /// <inheritdoc/>
    public HashingAlgorithm Algorithm => algorithm;

    /// <inheritdoc/>
    public void Append(ReadOnlySpan<byte> data) => implementation.Append(data);

    /// <inheritdoc/>
    public void Dispose() { }

    /// <inheritdoc/>
    public HashingResult GetHashAndReset()
    {
        Span<byte> digest = stackalloc byte[implementation.HashLengthInBytes];

        implementation.GetHashAndReset(digest);

        return new(this.Algorithm, digest.ToHexString());
    }
}
