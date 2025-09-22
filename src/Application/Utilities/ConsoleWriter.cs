namespace Hashx.Application;

/// <summary>
/// Defines methods for writing console messages.
/// </summary>
internal static class ConsoleWriter
{
    /// <summary>
    /// Writes an error message line.
    /// </summary>
    /// <param name="message">The error message.</param>
    internal static void WriteErrorLine(string message) => WriteColoredLine(message, ConsoleColor.Red);

    /// <summary>
    /// Writes a message line.
    /// </summary>
    /// <param name="message">The message.</param>
    internal static void WriteLine(string message) => Console.WriteLine(message);

    /// <summary>
    /// Writes a success message line.
    /// </summary>
    /// <param name="message">The success message.</param>
    internal static void WriteSuccessLine(string message) => WriteColoredLine(message, ConsoleColor.Green);

    private static void WriteColoredLine(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;

        Console.WriteLine(message);

        Console.ResetColor();
    }
}