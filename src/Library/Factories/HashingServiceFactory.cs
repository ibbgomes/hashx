namespace Hashx.Library;

/// <summary>
/// Defines a factory for creating instances of <see cref="IHashingService"/>.
/// </summary>
public static class HashingServiceFactory
{
    /// <summary>
    /// Creates an instance of <see cref="IHashingService"/> based on the specified <see cref="HashingAlgorithm"/>.
    /// </summary>
    /// <param name="algorithm">The algorithm.</param>
    /// <returns>The hashing service.</returns>
    public static IHashingService Create(HashingAlgorithm algorithm) => algorithm switch
    {
        HashingAlgorithm.MD5 or
        HashingAlgorithm.SHA1 or
        HashingAlgorithm.SHA256 or
        HashingAlgorithm.SHA384 or
        HashingAlgorithm.SHA512
            => CryptographicHashingServiceFactory.Create(algorithm),

        HashingAlgorithm.CRC32 or
        HashingAlgorithm.CRC64 or
        HashingAlgorithm.XXH128 or
        HashingAlgorithm.XXH3 or
        HashingAlgorithm.XXH32 or
        HashingAlgorithm.XXH64
            => NonCryptographicHashingServiceFactory.Create(algorithm),

        _ => throw new NotSupportedException($"The specified algorithm '{algorithm}' is not supported.")
    };
}