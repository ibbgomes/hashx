namespace Hashx.Library;

using System.IO.Hashing;

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
        string hash = implementation.GetHashAndReset().ToHexString();

        return new(this.Algorithm, hash);
    }
}