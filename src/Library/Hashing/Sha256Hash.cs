namespace Hashx.Library.Hashing
{
    using System.Security.Cryptography;

    /// <summary>
    /// Defines a <see cref="SHA256"/> implementation of a hashing algorithm.
    /// </summary>
    /// <seealso cref="Hashx.Library.Hashing.HashBase"/>
    public sealed class Sha256Hash : HashBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Sha256Hash"/> class.
        /// </summary>
        public Sha256Hash()
            : base()
        {
            this.Algorithm = new SHA256CryptoServiceProvider();
            this.Name = HashAlgorithmName.SHA256.Name;
        }

        #endregion
    }
}