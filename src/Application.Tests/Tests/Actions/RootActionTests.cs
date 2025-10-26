namespace Hashx.Application.Tests;

using System.CommandLine;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="RootAction"/>.
/// </summary>
public sealed class RootActionTests
{
    /// <summary>
    /// Tests that the <see cref="RootAction"/> returns the expected exit code and output when the algorithms option is provided with a duplicate valid value.
    /// </summary>
    [Fact]
    public void RootAction_Output_Algorithms_Duplicate()
    {
        StringWriter output = new();

        InvocationConfiguration configuration = new()
        {
            Output = output
        };

        string[] args =
        [
            Data.InputFilePath,
            "-a",
            "xxh3",
            "xxh3"
        ];

        string expectedOutput = $"{Hashes.XXH3}{Environment.NewLine}";

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke(configuration);

        Assert.Equal(ExitCodes.Success, exitCode);
        Assert.Equal(expectedOutput, output.ToString());
    }

    /// <summary>
    /// Tests that the <see cref="RootAction"/> returns the expected exit code and output when the algorithms option is provided with many valid values.
    /// </summary>
    [Fact]
    public void RootAction_Output_Algorithms_Many()
    {
        StringWriter output = new();

        InvocationConfiguration configuration = new()
        {
            Output = output
        };

        string[] args =
        [
            Data.InputFilePath,
            "-a",
            "xxh3",
            "xxh64",
        ];

        string expectedOutput = $"""
            XXH3   {Hashes.XXH3}
            XXH64  {Hashes.XXH64}{Environment.NewLine}
            """;

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke(configuration);

        Assert.Equal(ExitCodes.Success, exitCode);
        Assert.Equal(expectedOutput, output.ToString());
    }

    /// <summary>
    /// Tests that the <see cref="RootAction"/> returns the expected exit code and output when the algorithms option is provided with a single valid value.
    /// </summary>
    [Theory]
    [InlineData("-a", "md5", Hashes.MD5)]
    [InlineData("-a", "sha1", Hashes.SHA1)]
    [InlineData("-a", "sha256", Hashes.SHA256)]
    [InlineData("-a", "sha384", Hashes.SHA384)]
    [InlineData("-a", "sha512", Hashes.SHA512)]
    [InlineData("-a", "sha3_256", Hashes.SHA3_256)]
    [InlineData("-a", "sha3_384", Hashes.SHA3_384)]
    [InlineData("-a", "sha3_512", Hashes.SHA3_512)]
    [InlineData("-a", "crc32", Hashes.CRC32)]
    [InlineData("-a", "crc64", Hashes.CRC64)]
    [InlineData("-a", "xxh3", Hashes.XXH3)]
    [InlineData("-a", "xxh32", Hashes.XXH32)]
    [InlineData("-a", "xxh64", Hashes.XXH64)]
    [InlineData("-a", "xxh128", Hashes.XXH128)]
    public void RootAction_Output_Algorithms_Single(string option, string value, string hash)
    {
        StringWriter output = new();

        InvocationConfiguration configuration = new()
        {
            Output = output
        };

        string[] args =
        [
            Data.InputFilePath,
            option,
            value,
        ];

        string expectedOutput = $"{hash}{Environment.NewLine}";

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke(configuration);

        Assert.Equal(ExitCodes.Success, exitCode);
        Assert.Equal(expectedOutput, output.ToString());
    }

    /// <summary>
    /// Tests that the <see cref="RootAction"/> returns the expected exit code and output when the compare option is provided with a matching value.
    /// </summary>
    [Fact]
    public void RootAction_Output_Compare_Match()
    {
        StringWriter output = new();

        InvocationConfiguration configuration = new()
        {
            Output = output
        };

        string[] args =
        [
            Data.InputFilePath,
            "-a",
            "xxh3",
            "-c",
            Hashes.XXH3,
        ];

        string expectedOutput = $"""
            {Hashes.XXH3}
            XXH3 result matches the checksum.{Environment.NewLine}
            """;

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke(configuration);

        Assert.Equal(ExitCodes.Success, exitCode);
        Assert.Equal(expectedOutput, output.ToString());
    }

    /// <summary>
    /// Tests that the <see cref="RootAction"/> returns the expected exit code and output when the compare option is provided with a non-matching value.
    /// </summary>
    [Fact]
    public void RootAction_Output_Compare_Mismatch()
    {
        StringWriter output = new();

        InvocationConfiguration configuration = new()
        {
            Error = output
        };

        string[] args =
        [
            Data.InputFilePath,
            "-a",
            "xxh3",
            "-c",
            Hashes.XXH64,
        ];

        string expectedOutput = $"No result matches the checksum.{Environment.NewLine}";

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke(configuration);

        Assert.Equal(ExitCodes.ChecksumMismatch, exitCode);
        Assert.Equal(expectedOutput, output.ToString());
    }

    /// <summary>
    /// Tests that the <see cref="RootAction"/> returns the expected exit code and output when the JSON option is provided.
    /// </summary>
    [Fact]
    public void RootAction_Output_Json()
    {
        StringWriter output = new();

        InvocationConfiguration configuration = new()
        {
            Output = output
        };

        string[] args =
        [
            Data.InputFilePath,
            "-a",
            "xxh3",
            "--json",
        ];

        string expectedOutput = $$"""
            {
              "filename": "mock.json",
              "hashes": {
                "xxh3": "{{Hashes.XXH3}}"
              }
            }{{Environment.NewLine}}
            """;

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke(configuration);

        Assert.Equal(ExitCodes.Success, exitCode);
        Assert.Equal(expectedOutput, output.ToString());
    }

    /// <summary>
    /// Tests that the <see cref="RootAction"/> parsing fails when the algorithms option is provided without a value.
    /// </summary>
    [Fact]
    public void RootAction_Parsing_Algorithms_Empty()
    {
        string[] args =
        [
            Data.InputFilePath,
            "-a",
        ];

        ParseResult parseResult = new Application
            .RootCommand()
            .Parse(args);

        Assert.NotEmpty(parseResult.Errors);
    }

    /// <summary>
    /// Tests that the <see cref="RootAction"/> parsing fails when the algorithms option is provided with an invalid value.
    /// </summary>
    [Fact]
    public void RootAction_Parsing_Algorithms_Invalid()
    {
        string[] args =
        [
            Data.InputFilePath,
            "-a",
            "invalid"
        ];

        ParseResult parseResult = new Application
            .RootCommand()
            .Parse(args);

        Assert.NotEmpty(parseResult.Errors);
    }

    /// <summary>
    /// Tests that the <see cref="RootAction"/> parsing succeeds when the algorithms option is provided in its long form.
    /// </summary>
    [Fact]
    public void RootAction_Parsing_Algorithms_Long()
    {
        string[] args =
        [
            Data.InputFilePath,
            "--algorithms",
            "xxh3"
        ];

        ParseResult parseResult = new Application
            .RootCommand()
            .Parse(args);

        Assert.Empty(parseResult.Errors);
    }

    /// <summary>
    /// Tests that the <see cref="RootAction"/> parsing succeeds when the algorithms option is provided multiple times.
    /// </summary>
    [Fact]
    public void RootAction_Parsing_Algorithms_Multiple()
    {
        string[] args =
        [
            Data.InputFilePath,
            "-a",
            "xxh3",
            "-a",
            "xxh64",
        ];

        ParseResult parseResult = new Application
            .RootCommand()
            .Parse(args);

        Assert.Empty(parseResult.Errors);
    }

    /// <summary>
    /// Tests that the <see cref="RootAction"/> parsing fails when both the compare and JSON options are provided.
    /// </summary>
    [Fact]
    public void RootAction_Parsing_Compare_Json()
    {
        string[] args =
        [
            Data.InputFilePath,
            "-a",
            "xxh3",
            "-c",
            Hashes.MD5,
            "--json",
        ];

        ParseResult result = new Application
            .RootCommand()
            .Parse(args);

        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that the <see cref="RootAction"/> parsing succeeds when the compare option is provided in its long form.
    /// </summary>
    [Fact]
    public void RootAction_Parsing_Compare_Long()
    {
        string[] args =
        [
            Data.InputFilePath,
            "-a",
            "xxh3",
            "--compare",
            Hashes.XXH3,
        ];

        ParseResult parseResult = new Application
            .RootCommand()
            .Parse(args);

        Assert.Empty(parseResult.Errors);
    }

    /// <summary>
    /// Tests that the <see cref="RootAction"/> parsing fails when the input argument is missing
    /// </summary>
    [Fact]
    public void RootAction_Parsing_Input_Missing()
    {
        string[] args =
        [
            "-a",
            "xxh3"
        ];

        ParseResult parseResult = new Application
            .RootCommand()
            .Parse(args);

        Assert.NotEmpty(parseResult.Errors);
    }

    /// <summary>
    /// Tests that the <see cref="RootAction"/> parsing fails when the input argument is provided with a nonexistent file path.
    /// </summary>
    [Fact]
    public void RootAction_Parsing_Input_NonExistent()
    {
        string[] args =
        [
            "nonexistent",
            "-a",
            "xxh3"
        ];

        ParseResult parseResult = new Application
            .RootCommand()
            .Parse(args);

        Assert.NotEmpty(parseResult.Errors);
    }
}