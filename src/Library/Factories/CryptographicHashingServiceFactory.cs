using System.Security.Cryptography;

namespace Hashx.Library;

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
        HashAlgorithmName algorithmName = algorithm switch
        {
            HashingAlgorithm.MD5 => HashAlgorithmName.MD5,
            HashingAlgorithm.SHA1 => HashAlgorithmName.SHA1,
            HashingAlgorithm.SHA256 => HashAlgorithmName.SHA256,
            HashingAlgorithm.SHA384 => HashAlgorithmName.SHA384,
            HashingAlgorithm.SHA512 => HashAlgorithmName.SHA512,
            HashingAlgorithm.SHA3_256 => HashAlgorithmName.SHA3_256,
            HashingAlgorithm.SHA3_384 => HashAlgorithmName.SHA3_384,
            HashingAlgorithm.SHA3_512 => HashAlgorithmName.SHA3_512,
        };

        IncrementalHash implementation = IncrementalHash.CreateHash(algorithmName);

        return new(algorithm, implementation);
    }
}