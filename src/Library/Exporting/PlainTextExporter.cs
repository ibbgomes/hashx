namespace Hashx.Library.Exporting
{
    using System;
    using System.IO;
    using System.Text;
    using Hashx.Library.Contracts;
    using Hashx.Library.Models;

    /// <summary>
    /// Defines a plain-text exporter.
    /// </summary>
    /// <seealso cref="Hashx.Library.Contracts.IExporter"/>
    public sealed class PlainTextExporter : IExporter
    {
        #region Public Methods

        /// <inheritdoc/>
        public void Export(ExportableResult result, string path)
        {
            string plainText = GetPlainText(result);

            File.WriteAllText(path, plainText);
        }

        #endregion

        #region Private Methods

        private static string GetPlainText(ExportableResult result)
        {
            if (result is null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            StringBuilder builder = new StringBuilder();

            builder.Append($"{result.Filename}\n\n");

            foreach (HashResult hash in result.Hashes)
            {
                builder.Append($"{hash.Algorithm}\t{hash.Value}\n");
            }

            return builder.ToString();
        }

        #endregion
    }
}