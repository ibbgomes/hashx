namespace Hashx.Application.Tests;

using System.CommandLine;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="CustomHelpAction"/>.
/// </summary>
public sealed class CustomHelpActionTests
{
    /// <summary>
    /// Tests that the <see cref="CustomHelpAction"/> returns the expected exit code and custom output when the help option is provided.
    /// </summary>
    [Fact]
    public void CustomHelpAction_Output_Help()
    {
        StringWriter output = new();

        InvocationConfiguration configuration = new()
        {
            Output = output
        };

        string[] args =
        [
            "-h",
        ];

        const string customOutput = """
            Algorithms:
              crc32, crc64, md5, sha1, sha256, sha384, sha512, xxh128, xxh3, xxh32, xxh64

            Exit Codes:
              0  Success
              1  Processing error
              2  Checksum mismatch
            """;

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke(configuration);

        Assert.Equal(0, exitCode);
        Assert.Contains(customOutput, output.ToString());
    }
}