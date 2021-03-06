namespace Hashx.Application
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using Hashx.Application.Commands;

    /// <summary>
    /// The application.
    /// </summary>
    public class App
    {
        #region Public Methods

        /// <summary>
        /// Runs the application asynchronously.
        /// </summary>
        /// <param name="args">The application arguments.</param>
        /// <returns>The application exit code.</returns>
        [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Dependency injection.")]
        public async Task<int> RunAsync(string[] args)
        {
            RootCommand rootCommand = new ();

            return await rootCommand.InvokeAsync(args)
                .ConfigureAwait(false);
        }

        #endregion
    }
}