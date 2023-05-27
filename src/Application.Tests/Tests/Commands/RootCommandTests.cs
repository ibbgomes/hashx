namespace Hashx.Application.Tests;

using System.CommandLine;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="RootCommand"/>.
/// </summary>
[SuppressMessage("Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Unit tests.")]
[SuppressMessage("Style", "VSTHRD200:UseAsyncSuffixForAsyncMethods", Justification = "Unit tests.")]
public sealed class RootCommandTests
{
    #region Public Methods

    #region Algorithms Option

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the algorithms option and no value, runs unsuccessfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Empty()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(1);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the algorithms option and an invalid value,
    /// runs unsuccessfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Invalid()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "sha123",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(1);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the algorithms option and many values, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Many_1()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "md5",
            "-a",
            "sha1",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests the <see cref="RootCommand"/>, with the algorithms option and many values, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Many_2()
    {
        string[] args =
        {
            Data.MockFilePath,
            "--algorithm",
            "md5",
            "--algorithm",
            "sha1",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the algorithms option and the MD5 value, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Md5_1()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "md5",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that <see cref="RootCommand"/>, with the algorithms option and the MD5 value, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Md5_2()
    {
        string[] args =
        {
            Data.MockFilePath,
            "--algorithm",
            "md5",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that <see cref="RootCommand"/>, with the algorithms option and the MD5 value, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Md5_3()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "MD5",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the algorithms option before the file path
    /// argument, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Reversed()
    {
        string[] args =
        {
            "-a",
            "md5",
            Data.MockFilePath,
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that <see cref="RootCommand"/>, with the algorithms option and the SHA1 value, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Sha1_1()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "sha1",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the algorithms option and the SHA1 value,
    /// runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Sha1_2()
    {
        string[] args =
        {
            Data.MockFilePath,
            "--algorithm",
            "sha1",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the algorithms option and the SHA1 value,
    /// runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Sha1_3()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "SHA1",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the algorithms option and the SHA256 value,
    /// runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Sha256_1()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "sha256",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests the <see cref="RootCommand"/>, with the algorithms option and the SHA256 value, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Sha256_2()
    {
        string[] args =
        {
            Data.MockFilePath,
            "--algorithm",
            "sha256",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests the <see cref="RootCommand"/>, with the algorithms option and the SHA256 value, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Sha256_3()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "SHA256",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests the <see cref="RootCommand"/>, with the algorithms option and the SHA384 value, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Sha384_1()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "sha384",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the algorithms option and the SHA384 value,
    /// runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Sha384_2()
    {
        string[] args =
        {
            Data.MockFilePath,
            "--algorithm",
            "sha384",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the algorithms option and the SHA384 value,
    /// runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Sha384_3()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "SHA384",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the algorithms option and the SHA512 value,
    /// runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Sha512_1()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "sha512",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the algorithms option and the SHA512 value,
    /// runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Sha512_2()
    {
        string[] args =
        {
            Data.MockFilePath,
            "--algorithm",
            "sha512",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the algorithms option and the SHA512 value,
    /// runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Sha512_3()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "SHA512",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the algorithms option in uppercase, runs unsuccessfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Algorithms_Uppercase()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-A",
            "md5",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(1);
    }

    #endregion

    #region Compare Option

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the compare option and an expected value,
    /// runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Compare_Expected_1()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "md5",
            "-c",
            Hashes.MD5,
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the compare option and an expected value,
    /// runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Compare_Expected_2()
    {
        string[] args =
        {
            Data.MockFilePath,
            "--algorithm",
            "md5",
            "--compare",
            Hashes.MD5,
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with both the compare and JSON options, runs unsuccessfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Compare_Json()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "md5",
            "-c",
            Hashes.MD5,
            "--json",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(1);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the compare option before the algorithms
    /// option, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Compare_Reversed_1()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-c",
            Hashes.MD5,
            "-a",
            "md5",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the compare option before the algorithms
    /// option, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Compare_Reversed_2()
    {
        string[] args =
        {
            Data.MockFilePath,
            "--compare",
            Hashes.MD5,
            "--algorithm",
            "md5",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the compare option before the file path
    /// argument, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Compare_Reversed_3()
    {
        string[] args =
        {
            "-a",
            "md5",
            "-c",
            Hashes.MD5,
            Data.MockFilePath,
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the compare option and an unexpected value,
    /// runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Compare_Unexpected_1()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "md5",
            "-c",
            "unexpected-hash",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the compare option and an unexpected value,
    /// runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Compare_Unexpected_2()
    {
        string[] args =
        {
            Data.MockFilePath,
            "--algorithm",
            "md5",
            "--compare",
            "unexpected-hash",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the compare option in uppercase, runs unsuccessfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Compare_Uppercase()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "md5",
            "-C",
            Hashes.MD5,
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(1);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with both the compare and XML options, runs unsuccessfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Compare_Xml()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "md5",
            "-c",
            Hashes.MD5,
            "--xml",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(1);
    }

    #endregion

    #region JSON Option

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the JSON option and many algorithm, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Json_Many()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "md5",
            "-a",
            "sha1",
            "--json",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests the <see cref="RootCommand"/> with the JSON option before the algorithms option, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Json_Reversed_1()
    {
        string[] args =
        {
            Data.MockFilePath,
            "--json",
            "-a",
            "md5",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests the <see cref="RootCommand"/>, with the JSON option before the file path argument,
    /// runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Json_Reversed_2()
    {
        string[] args =
        {
            "-a",
            "md5",
            "--json",
            Data.MockFilePath,
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the JSON option and a single algorithm, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Json_Single()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "md5",
            "--json",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the JSON option in uppercase, runs unsuccessfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Json_Uppercase()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "md5",
            "--JSON",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(1);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with both the JSON and XML options, runs unsuccessfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Json_Xml()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "md5",
            "--json",
            "--xml",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(1);
    }

    #endregion

    #region XML Option

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the XML option and many algorithms, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Xml_Many()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "md5",
            "-a",
            "sha1",
            "--xml",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the XML option and a single algorithm, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Xml_Single()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "md5",
            "--xml",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    #endregion

    #region Version Option

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the version option, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Version()
    {
        string[] args =
        {
            "--version",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with both the version option and other options,
    /// run unsuccessfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Version_Exclusive()
    {
        string[] args =
        {
            Data.MockFilePath,
            "-a",
            "md5",
            "--version",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(1);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the version option in uppercase, runs unsuccessfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Version_Uppercase()
    {
        string[] args =
        {
            "--VERSION",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(1);
    }

    #endregion

    #region Help Option

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the help option, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Help_1()
    {
        string[] args =
        {
            "-h",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the help option, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Help_2()
    {
        string[] args =
        {
            "-?",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the help option, runs successfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Help_3()
    {
        string[] args =
        {
            "--help",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(0);
    }

    /// <summary>
    /// Tests that the <see cref="RootCommand"/>, with the help option in uppercase, runs unsuccessfully.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task RootCommand_Help_Uppercase()
    {
        string[] args =
        {
            "-H",
        };

        int exitCode = await new Application
            .RootCommand()
            .InvokeAsync(args)
            .ConfigureAwait(false);

        exitCode.Should().Be(1);
    }

    #endregion

    #endregion
}