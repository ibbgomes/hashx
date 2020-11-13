namespace Hashx.Library.Hashing
{
    using System.Security.Cryptography;

    /// <summary>
    /// Defines a <see cref="SHA384"/> implementation of a hashing algorithm.
    /// </summary>
    /// <seealso cref="Hashx.Library.Hashing.HashBase"/>
    public sealed class Sha384Hash : HashBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Sha384Hash"/> class.
        /// </summary>
        public Sha384Hash()
            : base()
        {
            this.Algorithm = new SHA384CryptoServiceProvider();
            this.Name = HashAlgorithmName.SHA384.Name;
        }

        #endregion
    }
}