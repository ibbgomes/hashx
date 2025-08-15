namespace Hashx.Library;

using System.IO.Hashing;

/// <summary>
/// Defines a <see cref="XxHash128"/> implementation of a non-cryptographic hashing service.
/// </summary>
/// <seealso cref="NonCryptographicHashingService"/>
internal sealed class Xxh128Service : NonCryptographicHashingService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Xxh128Service"/> class.
    /// </summary>
    internal Xxh128Service()
        : base(HashingAlgorithm.XXH128, new XxHash128())
    {
    }
}