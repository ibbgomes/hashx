namespace Hashx.Library;

using System.Security.Cryptography;

/// <summary>
/// Defines a factory for creating instances of <see cref="CryptographicHashingService"/>.
/// </summary>
internal static class CryptographicHashingServiceFactory
{
    /// <summary>
    /// Creates an instance of <see cref="CryptographicHashingService"/> based on the specified <see cref="HashingAlgorithm"/>.
    /// </summary>
    /// <param name="algorithm">The algorithm.</param>
    /// <returns>The cryptographic hashing service.</returns>
    internal static CryptographicHashingService Create(HashingAlgorithm algorithm)
    {
        HashAlgorithm implementation = algorithm switch
        {
            HashingAlgorithm.MD5 => MD5.Create(),
            HashingAlgorithm.SHA1 => SHA1.Create(),
            HashingAlgorithm.SHA256 => SHA256.Create(),
            HashingAlgorithm.SHA384 => SHA384.Create(),
            HashingAlgorithm.SHA512 => SHA512.Create(),
            HashingAlgorithm.SHA3_256 => SHA3_256.Create(),
            HashingAlgorithm.SHA3_384 => SHA3_384.Create(),
            HashingAlgorithm.SHA3_512 => SHA3_512.Create(),
        };

        return new(algorithm, implementation);
    }
}