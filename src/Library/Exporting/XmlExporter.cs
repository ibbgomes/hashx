namespace Hashx.Library.Exporting
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    using Hashx.Library.Contracts;
    using Hashx.Library.Models;

    /// <summary>
    /// Defines a XML exporter.
    /// </summary>
    /// <seealso cref="Hashx.Library.Contracts.IExporter"/>
    public sealed class XmlExporter : IExporter
    {
        #region Public Methods

        /// <summary>
        /// Serializes the specified <see cref="ExportableResult"/>.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>The XML string.</returns>
        public static string Serialize(ExportableResult result)
        {
            if (result is null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            XmlSerializer serializer = new XmlSerializer(result.GetType());

            using StringWriter writer = new StringWriter();

            serializer.Serialize(writer, result);

            return writer.ToString();
        }

        /// <inheritdoc/>
        public void Export(ExportableResult result, string path)
        {
            string text = Serialize(result);

            File.WriteAllText(path, text);
        }

        #endregion
    }
}