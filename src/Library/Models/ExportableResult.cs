namespace Hashx.Library.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    /// <summary>
    /// Defines an exportable result.
    /// </summary>
    /// <seealso cref="Hashx.Library.Contracts.IResult"/>
    [XmlType(TypeName = "Result")]
    public class ExportableResult
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportableResult"/> class.
        /// </summary>
        public ExportableResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportableResult"/> class.
        /// </summary>
        /// <param name="fileInfo">The file information.</param>
        /// <param name="hashes">The hashes.</param>
        public ExportableResult(FileInfo fileInfo, IEnumerable<HashResult> hashes)
        {
            if (fileInfo is null)
            {
                throw new ArgumentNullException(nameof(fileInfo));
            }

            if (!hashes.Any())
            {
                throw new ArgumentNullException(nameof(hashes));
            }

            this.Filename = fileInfo.Name;
            this.Hashes = hashes.ToList();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Gets the hashes.
        /// </summary>
        public List<HashResult> Hashes { get; }

        #endregion
    }
}