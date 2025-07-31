namespace Hashx.Application.Tests;

using System.CommandLine;
using FluentAssertions;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="RootCommand"/>.
/// </summary>
public sealed class RootCommandTests
{
    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs unsuccessfully when the algorithms option is
    /// provided without a value.
    /// </summary>
    [Fact]
    public void RootCommand_Algorithms_Empty()
    {
        string[] args =
        [
            Data.MockFilePath,
            "-a",
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(1);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs unsuccessfully when the algorithms option is
    /// provided with an invalid value.
    /// </summary>
    [Fact]
    public void RootCommand_Algorithms_Invalid()
    {
        string[] args =
        [
            Data.MockFilePath,
            "-a",
            "sha123",
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(1);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs successfully when the algorithms option is
    /// provided with many valid values.
    /// </summary>
    [Fact]
    public void RootCommand_Algorithms_Many_1()
    {
        string[] args =
        [
            Data.MockFilePath,
            "-a",
            "md5",
            "sha1",
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs successfully when the algorithms option is
    /// provided with many valid values.
    /// </summary>
    [Fact]
    public void RootCommand_Algorithms_Many_2()
    {
        string[] args =
        [
            Data.MockFilePath,
            "-a",
            "md5",
            "-a",
            "sha1",
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs successfully when the algorithms option is
    /// provided with many valid values.
    /// </summary>
    [Fact]
    public void RootCommand_Algorithms_Many_3()
    {
        string[] args =
        [
            Data.MockFilePath,
            "--algorithms",
            "md5",
            "sha1",
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs successfully when the algorithms option is
    /// provided with many valid values.
    /// </summary>
    [Fact]
    public void RootCommand_Algorithms_Many_4()
    {
        string[] args =
        [
            Data.MockFilePath,
            "--algorithms",
            "md5",
            "--algorithms",
            "sha1",
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs unsuccessfully when the algorithms option is
    /// provided before the file path argument.
    /// </summary>
    [Fact]
    public void RootCommand_Algorithms_Reversed()
    {
        string[] args =
        [
            "-a",
            "md5",
            Data.MockFilePath,
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(1);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs successfully when the algorithms option is
    /// provided with a single valid value.
    /// </summary>
    [Theory]
    [InlineData("-a", "md5")]
    [InlineData("-a", "sha1")]
    [InlineData("-a", "sha256")]
    [InlineData("-a", "sha384")]
    [InlineData("-a", "sha512")]
    [InlineData("--algorithms", "md5")]
    [InlineData("--algorithms", "sha1")]
    [InlineData("--algorithms", "sha256")]
    [InlineData("--algorithms", "sha384")]
    [InlineData("--algorithms", "sha512")]
    public void RootCommand_Algorithms_Single(string option, string value)
    {
        string[] args =
        [
            Data.MockFilePath,
            option,
            value,
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs unsuccessfully when the algorithms option is
    /// provided in uppercase.
    /// </summary>
    [Fact]
    public void RootCommand_Algorithms_Uppercase()
    {
        string[] args =
        [
            Data.MockFilePath,
            "-A",
            "md5",
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(1);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs successfully when the compare option is
    /// provided with an expected value.
    /// </summary>
    [Fact]
    public void RootCommand_Compare_Expected_1()
    {
        string[] args =
        [
            Data.MockFilePath,
            "-a",
            "md5",
            "-c",
            Hashes.MD5,
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs successfully when the compare option is
    /// provided with an expected value.
    /// </summary>
    [Fact]
    public void RootCommand_Compare_Expected_2()
    {
        string[] args =
        [
            Data.MockFilePath,
            "--algorithms",
            "md5",
            "--compare",
            Hashes.MD5,
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs unsuccessfully when both the compare and JSON
    /// options are provided.
    /// </summary>
    [Fact]
    public void RootCommand_Compare_Json()
    {
        string[] args =
        [
            Data.MockFilePath,
            "-a",
            "md5",
            "-c",
            Hashes.MD5,
            "--json",
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(1);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs successfully when the compare option is
    /// provided before the algorithms option.
    /// </summary>
    [Fact]
    public void RootCommand_Compare_Reversed_1()
    {
        string[] args =
        [
            Data.MockFilePath,
            "-c",
            Hashes.MD5,
            "-a",
            "md5",
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs successfully when the compare option is
    /// provided before the algorithms option.
    /// </summary>
    [Fact]
    public void RootCommand_Compare_Reversed_2()
    {
        string[] args =
        [
            Data.MockFilePath,
            "--compare",
            Hashes.MD5,
            "--algorithms",
            "md5",
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs successfully when the compare option is
    /// provided before the file path argument.
    /// </summary>
    [Fact]
    public void RootCommand_Compare_Reversed_3()
    {
        string[] args =
        [
            "-a",
            "md5",
            "-c",
            Hashes.MD5,
            Data.MockFilePath,
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs successfully when the compare option is
    /// provided with an unexpected value.
    /// </summary>
    [Fact]
    public void RootCommand_Compare_Unexpected_1()
    {
        string[] args =
        [
            Data.MockFilePath,
            "-a",
            "md5",
            "-c",
            "unexpected-hash",
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs successfully when the compare option is
    /// provided with an unexpected value.
    /// </summary>
    [Fact]
    public void RootCommand_Compare_Unexpected_2()
    {
        string[] args =
        [
            Data.MockFilePath,
            "--algorithms",
            "md5",
            "--compare",
            "unexpected-hash",
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs unsuccessfully when the compare option is
    /// provided in uppercase.
    /// </summary>
    [Fact]
    public void RootCommand_Compare_Uppercase()
    {
        string[] args =
        [
            Data.MockFilePath,
            "-a",
            "md5",
            "-C",
            Hashes.MD5,
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(1);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs successfully when the help option is provided.
    /// </summary>
    [Theory]
    [InlineData("-?")]
    [InlineData("-h")]
    [InlineData("--help")]
    public void RootCommand_Help(string option)
    {
        int exitCode = new Application
            .RootCommand()
            .Parse(option)
            .Invoke();

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs unsuccessfully when the help option is
    /// provided in uppercase.
    /// </summary>
    [Fact]
    public void RootCommand_Help_Uppercase()
    {
        string[] args =
        [
            "-H",
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(1);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs successfully when the JSON option is provided
    /// with many algorithms.
    /// </summary>
    [Fact]
    public void RootCommand_Json_Many()
    {
        string[] args =
        [
            Data.MockFilePath,
            "-a",
            "md5",
            "-a",
            "sha1",
            "--json",
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs successfully when the JSON option is provided
    /// before the algorithms option.
    /// </summary>
    [Fact]
    public void RootCommand_Json_Reversed_1()
    {
        string[] args =
        [
            Data.MockFilePath,
            "--json",
            "-a",
            "md5",
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs successfully when the JSON option is provided
    /// before the file path argument.
    /// </summary>
    [Fact]
    public void RootCommand_Json_Reversed_2()
    {
        string[] args =
        [
            "-a",
            "md5",
            "--json",
            Data.MockFilePath,
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs successfully when the JSON option is provided
    /// with a single algorithm.
    /// </summary>
    [Fact]
    public void RootCommand_Json_Single()
    {
        string[] args =
        [
            Data.MockFilePath,
            "-a",
            "md5",
            "--json",
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs unsuccessfully when the JSON option is
    /// provided in uppercase.
    /// </summary>
    [Fact]
    public void RootCommand_Json_Uppercase()
    {
        string[] args =
        [
            Data.MockFilePath,
            "-a",
            "md5",
            "--JSON",
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(1);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs successfully when the version option is provided.
    /// </summary>
    [Fact]
    public void RootCommand_Version()
    {
        string[] args =
        [
            "--version",
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/> runs unsuccessfully when the version option is
    /// provided in uppercase.
    /// </summary>
    [Fact]
    public void RootCommand_Version_Uppercase()
    {
        string[] args =
        [
            "--VERSION",
        ];

        int exitCode = new Application
            .RootCommand()
            .Parse(args)
            .Invoke();

        exitCode.Should().Be(1);
    }
}