namespace Hashx.Library;

using System.IO.Hashing;

/// <summary>
/// Defines a <see cref="Crc32"/> implementation of a non-cryptographic hashing service.
/// </summary>
/// <seealso cref="NonCryptographicHashingService"/>
internal sealed class Crc32Service : NonCryptographicHashingService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Crc32Service"/> class.
    /// </summary>
    internal Crc32Service()
        : base(HashingAlgorithm.CRC32, new Crc32())
    {
    }
}