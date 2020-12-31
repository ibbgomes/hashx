namespace Hashx.Library.Exporting
{
    using System;
    using System.IO;
    using System.Text.Json;
    using Hashx.Library.Contracts;
    using Hashx.Library.Models;

    /// <summary>
    /// Defines a JSON exporter.
    /// </summary>
    /// <seealso cref="Hashx.Library.Contracts.IExporter"/>
    public sealed class JsonExporter : IExporter
    {
        #region Public Methods

        /// <summary>
        /// Serializes the specified <see cref="ExportableResult"/>.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>The JSON string.</returns>
        public static string Serialize(ExportableResult result)
        {
            if (result is null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            return JsonSerializer.Serialize(result, options);
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