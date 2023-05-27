namespace Hashx.Application;

using System.CommandLine;
using System.Threading.Tasks;

/// <summary>
/// Defines the starting point of the program.
/// </summary>
internal static class Program
{
    #region Private Methods

    private static Task<int> Main(string[] args)
    {
        return new RootCommand()
            .InvokeAsync(args);
    }

    #endregion
}