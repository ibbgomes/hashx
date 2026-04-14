namespace Hashx.Application;

/// <summary>
/// Defines exit codes used in the application.
/// </summary>
internal static class ExitCodes
{
    /// <summary>
    /// Indicates that the application executed successfully.
    /// </summary>
    internal const int Success = 0;

    /// <summary>
    /// Indicates that an error occurred during application processing.
    /// </summary>
    internal const int ProcessingError = 1;

    /// <summary>
    /// Indicates that a hash mismatch occurred.
    /// </summary>
    internal const int HashMismatch = 2;
}