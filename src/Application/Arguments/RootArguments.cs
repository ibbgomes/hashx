namespace Hashx.Application.Arguments
{
    using System.IO;
    using Hashx.Application.Commands;

    /// <summary>
    /// Defines the <see cref="RootCommand"/> arguments.
    /// </summary>
    internal sealed class RootArguments
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the hashing algorithms used to generate the checksums.
        /// </summary>
        public string[] Algorithms { get; set; }

        /// <summary>
        /// Gets or sets the string that should be compared against the checksums.
        /// </summary>
        public string Compare { get; set; }

        /// <summary>
        /// Gets or sets the file used to generate the checksums.
        /// </summary>
        public FileInfo Input { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the output should be JSON.
        /// </summary>
        public bool Json { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the output should be XML.
        /// </summary>
        public bool Xml { get; set; }

        #endregion
    }
}