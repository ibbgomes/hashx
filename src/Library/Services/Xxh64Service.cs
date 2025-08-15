namespace Hashx.Library;

using System.IO.Hashing;

/// <summary>
/// Defines a <see cref="XxHash64"/> implementation of a non-cryptographic hashing service.
/// </summary>
/// <seealso cref="NonCryptographicHashingService"/>
internal sealed class Xxh64Service : NonCryptographicHashingService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Xxh64Service"/> class.
    /// </summary>
    internal Xxh64Service()
        : base(HashingAlgorithm.XXH64, new XxHash64())
    {
    }
}