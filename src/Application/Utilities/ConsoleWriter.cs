namespace Hashx.Application;

/// <summary>
/// Provides methods for writing messages to the console.
/// </summary>
internal static class ConsoleWriter
{
    /// <summary>
    /// Writes a message.
    /// </summary>
    /// <param name="message">The message.</param>
    internal static void Write(string message) => Console.WriteLine(message);

    /// <summary>
    /// Writes an error message.
    /// </summary>
    /// <param name="message">The message.</param>
    internal static void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        Console.Error.WriteLine(message);

        Console.ResetColor();
    }

    /// <summary>
    /// Writes a success message.
    /// </summary>
    /// <param name="message">The message.</param>
    internal static void WriteSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine(message);

        Console.ResetColor();
    }
}