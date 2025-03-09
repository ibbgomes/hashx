namespace Hashx.Application;

using System.CommandLine;

/// <summary>
/// Defines the starting point of the program.
/// </summary>
internal static class Program
{
    #region Private Methods

    private static int Main(string[] args) => new RootCommand().Invoke(args);

    #endregion
}