namespace Hashx.Application;

/// <summary>
/// Defines extension methods for <see cref="TextWriter"/> arrays.
/// </summary>
internal static class TextWriterExtensions
{
    /// <summary>
    /// Writes an error message line.
    /// </summary>
    /// <param name="writer">The text writer.</param>
    /// <param name="message">The error message.</param>
    internal static void WriteErrorLine(this TextWriter writer, string message) => WriteColoredLine(writer, message, ConsoleColor.Red);

    /// <summary>
    /// Writes a success message line.
    /// </summary>
    /// <param name="writer">The text writer.</param>
    /// <param name="message">The success message.</param>
    internal static void WriteSuccessLine(this TextWriter writer, string message) => WriteColoredLine(writer, message, ConsoleColor.Green);

    private static void WriteColoredLine(this TextWriter writer, string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;

        writer.WriteLine(message);

        Console.ResetColor();
    }
}