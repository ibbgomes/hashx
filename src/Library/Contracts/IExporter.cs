namespace Hashx.Library.Contracts
{
    using Hashx.Library.Models;

    /// <summary>
    /// Defines the contract of an exporter.
    /// </summary>
    public interface IExporter
    {
        #region Methods

        /// <summary>
        /// Exports the specified <see cref="ExportableResult"/> to the specified path.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="path">The path.</param>
        void Export(ExportableResult result, string path);

        #endregion
    }
}