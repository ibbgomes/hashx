namespace Hashx.Library.Hashing
{
    using System.Security.Cryptography;

    /// <summary>
    /// Defines a <see cref="SHA1"/> implementation of a hashing algorithm.
    /// </summary>
    /// <seealso cref="Hashx.Library.Hashing.HashBase"/>
    public sealed class Sha1Hash : HashBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Sha1Hash"/> class.
        /// </summary>
        public Sha1Hash()
            : base()
        {
            this.Algorithm = new SHA1CryptoServiceProvider();
            this.Name = HashAlgorithmName.SHA1.Name;
        }

        #endregion
    }
}