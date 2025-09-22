namespace Hashx.Library;

using System.IO.Hashing;

/// <summary>
/// Defines a factory for creating instances of <see cref="NonCryptographicHashingService"/>.
/// </summary>
internal static class NonCryptographicHashingServiceFactory
{
    /// <summary>
    /// Creates an instance of <see cref="NonCryptographicHashingService"/> based on the specified <see cref="HashingAlgorithm"/>.
    /// </summary>
    /// <param name="algorithm">The algorithm.</param>
    /// <returns>The non-cryptographic hashing service.</returns>
    internal static NonCryptographicHashingService Create(HashingAlgorithm algorithm)
    {
        NonCryptographicHashAlgorithm implementation = algorithm switch
        {
            HashingAlgorithm.CRC32 => new Crc32(),
            HashingAlgorithm.CRC64 => new Crc64(),
            HashingAlgorithm.XXH128 => new XxHash128(),
            HashingAlgorithm.XXH3 => new XxHash3(),
            HashingAlgorithm.XXH32 => new XxHash32(),
            HashingAlgorithm.XXH64 => new XxHash64(),
        };

        return new(algorithm, implementation);
    }
}