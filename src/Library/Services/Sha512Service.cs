namespace Hashx.Library;

using System.Security.Cryptography;

/// <summary>
/// Defines a <see cref="SHA512"/> implementation of a cryptographic hashing service.
/// </summary>
/// <seealso cref="CryptographicHashingService"/>
internal sealed class Sha512Service : CryptographicHashingService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Sha512Service"/> class.
    /// </summary>
    internal Sha512Service()
        : base(HashingAlgorithm.SHA512, SHA512.Create())
    {
    }
}