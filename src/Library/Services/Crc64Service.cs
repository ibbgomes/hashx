namespace Hashx.Library;

using System.IO.Hashing;

/// <summary>
/// Defines a <see cref="Crc64"/> implementation of a non-cryptographic hashing service.
/// </summary>
/// <seealso cref="NonCryptographicHashingService"/>
internal sealed class Crc64Service : NonCryptographicHashingService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Crc64Service"/> class.
    /// </summary>
    internal Crc64Service()
        : base(HashingAlgorithm.CRC64, new Crc64())
    {
    }
}