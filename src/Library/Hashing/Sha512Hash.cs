namespace Hashx.Library.Hashing
{
    using System.Security.Cryptography;

    /// <summary>
    /// Defines a <see cref="SHA512"/> implementation of a hashing algorithm.
    /// </summary>
    /// <seealso cref="Hashx.Library.Hashing.HashBase"/>
    public sealed class Sha512Hash : HashBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Sha512Hash"/> class.
        /// </summary>
        public Sha512Hash()
            : base()
        {
            this.Algorithm = new SHA512CryptoServiceProvider();
            this.Name = HashAlgorithmName.SHA512.Name;
        }

        #endregion
    }
}