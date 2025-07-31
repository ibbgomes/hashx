namespace Hashx.Library;

using System.Security.Cryptography;

/// <summary>
/// Defines a <see cref="SHA384"/> implementation of a hashing service.
/// </summary>
/// <seealso cref="HashingService"/>
internal sealed class Sha384Service : HashingService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Sha384Service"/> class.
    /// </summary>
    internal Sha384Service()
        : base(HashingAlgorithm.SHA384, SHA384.Create())
    {
    }
}