namespace Hashx.Library;

using System.Security.Cryptography;

/// <summary>
/// Defines a <see cref="SHA256"/> implementation of a hashing service.
/// </summary>
/// <seealso cref="HashingService"/>
internal sealed class Sha256Service : HashingService
{
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="Sha256Service"/> class.
    /// </summary>
    internal Sha256Service()
        : base(HashingAlgorithm.SHA256, SHA256.Create())
    {
    }

    #endregion
}