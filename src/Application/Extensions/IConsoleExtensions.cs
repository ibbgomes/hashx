namespace Hashx.Application;

using System.CommandLine;
using System.CommandLine.IO;

/// <summary>
/// Provides extension methods for <see cref="IConsole"/>.
/// </summary>
internal static class IConsoleExtensions
{
    #region Internal Methods

    /// <summary>
    /// Writes a message.
    /// </summary>
    /// <param name="console">The console.</param>
    /// <param name="message">The message.</param>
    internal static void Write(this IConsole console, string message)
    {
        console.Out.WriteLine(message);
    }

    /// <summary>
    /// Writes an error message.
    /// </summary>
    /// <param name="console">The console.</param>
    /// <param name="message">The message.</param>
    internal static void WriteError(this IConsole console, string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        console.Error.WriteLine(message);

        Console.ResetColor();
    }

    /// <summary>
    /// Writes a success message.
    /// </summary>
    /// <param name="console">The console.</param>
    /// <param name="message">The message.</param>
    internal static void WriteSuccess(this IConsole console, string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;

        console.Out.WriteLine(message);

        Console.ResetColor();
    }

    #endregion
}