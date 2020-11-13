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

        /// <inheritdoc/>
        public void Export(ExportableResult result, string path)
        {
            string text = Serialize(result);

            File.WriteAllText(path, text);
        }

        #endregion

        #region Private Methods

        private static string Serialize(ExportableResult result)
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

        #endregion
    }
}