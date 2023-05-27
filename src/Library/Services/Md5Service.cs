namespace Hashx.Library;

using System.Security.Cryptography;

/// <summary>
/// Defines a <see cref="MD5"/> implementation of a hashing service.
/// </summary>
/// <seealso cref="HashingService"/>
internal sealed class Md5Service : HashingService
{
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="Md5Service"/> class.
    /// </summary>
    internal Md5Service()
        : base(HashingAlgorithm.MD5, MD5.Create())
    {
    }

    #endregion
}