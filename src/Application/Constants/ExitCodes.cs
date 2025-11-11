namespace Hashx.Application;

/// <summary>
/// Defines exit codes used in the application.
/// </summary>
internal static class ExitCodes
{
    /// <summary>
    /// Indicates that a checksum mismatch occurred.
    /// </summary>
    internal const int ChecksumMismatch = 2;

    /// <summary>
    /// Indicates that an error occurred during application processing.
    /// </summary>
    internal const int ProcessingError = 1;

    /// <summary>
    /// Indicates that the application executed successfully.
    /// </summary>
    internal const int Success = 0;
}