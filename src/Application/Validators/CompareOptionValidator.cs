using System.CommandLine.Parsing;

namespace Hashx.Application;

/// <summary>
/// Defines the validator for the <see cref="RootCommand"/> compare option.
/// </summary>
internal static class CompareOptionValidator
{
    /// <summary>
    /// Validates the compare option value.
    /// </summary>
    internal static void Validate(OptionResult result)
    {
        string value = result.Tokens[0].Value;

        if (string.IsNullOrWhiteSpace(value))
        {
            result.AddError("The expected hash cannot be empty.");

            return;
        }

        if (!value.All(char.IsAsciiHexDigit))
        {
            result.AddError("The expected hash must be a hexadecimal string.");
        }
    }
}
