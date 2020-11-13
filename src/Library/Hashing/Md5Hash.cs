namespace Hashx.Library.Hashing
{
    using System.Security.Cryptography;

    /// <summary>
    /// Defines a <see cref="MD5"/> implementation of a hashing algorithm.
    /// </summary>
    /// <seealso cref="Hashx.Library.Hashing.HashBase"/>
    public sealed class Md5Hash : HashBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Md5Hash"/> class.
        /// </summary>
        public Md5Hash()
            : base()
        {
            this.Algorithm = new MD5CryptoServiceProvider();
            this.Name = HashAlgorithmName.MD5.Name;
        }

        #endregion
    }
}