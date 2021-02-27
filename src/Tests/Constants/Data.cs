namespace Hashx.Tests.Constants
{
    /// <summary>
    /// Defines constants related with unit tests data.
    /// </summary>
    internal class Data
    {
        /// <summary>
        /// The path of the file that results in a expected hash.
        /// </summary>
        internal const string ExpectedHashFilePath = @"Data/expected-hash.json";

        /// <summary>
        /// The invalid file path.
        /// </summary>
        internal const string InvalidFilePath = @"Data/invalid-path.json";

        /// <summary>
        /// The path of the file that contains a JSON exportable result.
        /// </summary>
        internal const string JsonExportFilePath = @"Data/exportable-result.json";

        /// <summary>
        /// The path of the file that contains a XML exportable result.
        /// </summary>
        internal const string XmlExportFilePath = @"Data/exportable-result.xml";
    }
}