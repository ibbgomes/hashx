namespace Hashx.Library;

using System;

/// <summary>
/// Defines an <see cref="IHashingService"/> factory.
/// </summary>
public static class HashingServiceFactory
{
    #region Public Methods

    /// <summary>
    /// Gets an instance of an <see cref="IHashingService"/> through the specified <see cref="HashingAlgorithm"/>.
    /// </summary>
    /// <param name="algorithm">The hashing algorithm.</param>
    /// <returns>The hashing service instance.</returns>
    public static IHashingService GetInstance(HashingAlgorithm algorithm)
    {
        return algorithm switch
        {
            HashingAlgorithm.MD5 => new Md5Service(),
            HashingAlgorithm.SHA1 => new Sha1Service(),
            HashingAlgorithm.SHA256 => new Sha256Service(),
            HashingAlgorithm.SHA384 => new Sha384Service(),
            HashingAlgorithm.SHA512 => new Sha512Service(),
            _ => throw new InvalidOperationException("The specified algorithm is invalid."),
        };
    }

    #endregion
}