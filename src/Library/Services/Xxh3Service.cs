namespace Hashx.Library;

using System.IO.Hashing;

/// <summary>
/// Defines a <see cref="XxHash3"/> implementation of a non-cryptographic hashing service.
/// </summary>
/// <seealso cref="NonCryptographicHashingService"/>
internal sealed class Xxh3Service : NonCryptographicHashingService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Xxh3Service"/> class.
    /// </summary>
    internal Xxh3Service()
        : base(HashingAlgorithm.XXH3, new XxHash3())
    {
    }
}