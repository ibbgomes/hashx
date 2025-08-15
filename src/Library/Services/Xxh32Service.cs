namespace Hashx.Library;

using System.IO.Hashing;

/// <summary>
/// Defines a <see cref="XxHash32"/> implementation of a non-cryptographic hashing service.
/// </summary>
/// <seealso cref="NonCryptographicHashingService"/>
internal sealed class Xxh32Service : NonCryptographicHashingService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Xxh32Service"/> class.
    /// </summary>
    internal Xxh32Service()
        : base(HashingAlgorithm.XXH32, new XxHash32())
    {
    }
}