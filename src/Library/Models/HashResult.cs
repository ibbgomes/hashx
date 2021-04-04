namespace Hashx.Library.Models
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// Defines a hashing operation result.
    /// </summary>
    [XmlType(TypeName = "Hash")]
    public class HashResult
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HashResult"/> class.
        /// </summary>
        public HashResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HashResult"/> class.
        /// </summary>
        /// <param name="algorithm">The hashing algorithm.</param>
        /// <param name="hash">The hashing operation resulting hash.</param>
        public HashResult(string algorithm, string hash)
        {
            if (string.IsNullOrEmpty(algorithm))
            {
                throw new ArgumentNullException(nameof(algorithm));
            }

            if (string.IsNullOrEmpty(hash))
            {
                throw new ArgumentNullException(nameof(hash));
            }

            this.Algorithm = algorithm;
            this.Value = hash;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the algorithm used in the hashing operation.
        /// </summary>
        [XmlAttribute]
        public string Algorithm { get; set; }

        /// <summary>
        /// Gets or sets the hashing operation resulting value.
        /// </summary>
        [XmlAttribute]
        public string Value { get; set; }

        #endregion
    }
}