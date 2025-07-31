namespace Hashx.Library;

using System.Security.Cryptography;

/// <summary>
/// Defines a <see cref="SHA1"/> implementation of a hashing service.
/// </summary>
/// <seealso cref="HashingService"/>
internal sealed class Sha1Service : HashingService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Sha1Service"/> class.
    /// </summary>
    internal Sha1Service()
        : base(HashingAlgorithm.SHA1, SHA1.Create())
    {
    }
}