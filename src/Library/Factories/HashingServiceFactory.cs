namespace Hashx.Library;

/// <summary>
/// Defines an <see cref="IHashingService"/> factory.
/// </summary>
public static class HashingServiceFactory
{
    /// <summary>
    /// Gets an instance of an <see cref="IHashingService"/> through the specified <see cref="HashingAlgorithm"/>.
    /// </summary>
    /// <param name="algorithm">The hashing algorithm.</param>
    /// <returns>The hashing service instance.</returns>
    public static IHashingService GetInstance(HashingAlgorithm algorithm) => algorithm switch
    {
        HashingAlgorithm.MD5 => new Md5Service(),
        HashingAlgorithm.SHA1 => new Sha1Service(),
        HashingAlgorithm.SHA256 => new Sha256Service(),
        HashingAlgorithm.SHA384 => new Sha384Service(),
        HashingAlgorithm.SHA512 => new Sha512Service(),
        HashingAlgorithm.CRC32 => new Crc32Service(),
        HashingAlgorithm.CRC64 => new Crc64Service(),
        _ => throw new InvalidOperationException("The specified algorithm is invalid."),
    };
}