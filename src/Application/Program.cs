namespace Hashx.Application
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Defines the starting point of the program.
    /// </summary>
    internal static class Program
    {
        #region Private Methods

        /// <summary>
        /// Configures and executes the application asynchronously.
        /// </summary>
        private static async Task<int> Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<App, App>()
                .BuildServiceProvider();

            return await serviceProvider.GetService<App>().RunAsync(args)
                .ConfigureAwait(false);
        }

        #endregion
    }
}