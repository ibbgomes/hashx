namespace Hashx.Application;

/// <summary>
/// Defines the starting point of the program.
/// </summary>
internal static class Program
{
    private static int Main(string[] args) => new RootCommand().Parse(args).Invoke();
}