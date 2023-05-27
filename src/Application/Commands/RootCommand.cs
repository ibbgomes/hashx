namespace Hashx.Application;

using System.CommandLine;
using System.IO;
using Hashx.Library;

/// <summary>
/// Defines the root command.
/// </summary>
/// <seealso cref="System.CommandLine.RootCommand"/>
internal sealed class RootCommand : System.CommandLine.RootCommand
{
    #region Fields

    private readonly Option<HashingAlgorithm[]> algorithmOption = new(new[] { "-a", "--algorithm" })
    {
        Description = "Specify a hashing algorithm",
        IsRequired = true,
        Arity = ArgumentArity.OneOrMore,
    };

    private readonly Option<string> compareOption = new(new[] { "-c", "--compare" })
    {
        Description = "Compare the results against a checksum",
        IsRequired = false,
    };

    private readonly Argument<FileInfo> inputArgument = new Argument<FileInfo>()
    {
        Name = "input",
        Description = "Specify the input file path",
        Arity = ArgumentArity.ExactlyOne,
    }.ExistingOnly();

    private readonly Option<bool> jsonOption = new("--json")
    {
        Description = "Print the results in JSON format",
        IsRequired = false,
    };

    private readonly Option<bool> xmlOption = new("--xml")
    {
        Description = "Print the results in XML format",
        IsRequired = false,
    };

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="RootCommand"/> class.
    /// </summary>
    public RootCommand()
        : base("A cross-platform, command-line interface, checksum utility")
    {
        this.AddArguments();

        this.AddOptions();

        this.AddValidators();

        this.SetHandler();
    }

    #endregion

    #region Private Methods

    private void AddArguments()
    {
        this.AddArgument(this.inputArgument);
    }

    private void AddOptions()
    {
        this.AddOption(this.algorithmOption);

        this.AddOption(this.compareOption);

        this.AddOption(this.jsonOption);

        this.AddOption(this.xmlOption);
    }

    private void AddValidators()
    {
        this.AddValidator(
            (result) =>
            {
                bool jsonOption = result.GetValueForOption(this.jsonOption);

                bool xmlOption = result.GetValueForOption(this.xmlOption);

                if (jsonOption && xmlOption)
                {
                    result.ErrorMessage = "Options '--json' and '--xml' cannot be used together.";
                }
            });

        this.AddValidator(
            (result) =>
            {
                string? compareOption = result.GetValueForOption(this.compareOption);

                bool jsonOption = result.GetValueForOption(this.jsonOption);

                if (compareOption is not null && jsonOption)
                {
                    result.ErrorMessage = "Options '--compare' and '--json' cannot be used together.";
                }
            });

        this.AddValidator(
            (result) =>
            {
                string? compareOption = result.GetValueForOption(this.compareOption);

                bool xmlOption = result.GetValueForOption(this.xmlOption);

                if (compareOption is not null && xmlOption)
                {
                    result.ErrorMessage = "Options '--compare' and '--xml' cannot be used together.";
                }
            });
    }

    private void SetHandler()
    {
        this.SetHandler(
            (context) =>
            {
                RootArguments args = new()
                {
                    Input = context.ParseResult.GetValueForArgument(this.inputArgument),
                    Algorithms = context.ParseResult.GetValueForOption(this.algorithmOption)!,
                    Checksum = context.ParseResult.GetValueForOption(this.compareOption),
                    Json = context.ParseResult.GetValueForOption(this.jsonOption),
                    Xml = context.ParseResult.GetValueForOption(this.xmlOption),
                };

                RootHandler.Handle(args, context.Console);
            });
    }

    #endregion
}