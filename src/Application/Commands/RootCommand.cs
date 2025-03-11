namespace Hashx.Application;

using System.CommandLine;
using Hashx.Library;

/// <summary>
/// Defines the root command.
/// </summary>
/// <seealso cref="System.CommandLine.RootCommand"/>
internal sealed class RootCommand : System.CommandLine.RootCommand
{
    #region Fields

    private readonly Option<HashingAlgorithm[]> algorithmsOption = new(["-a", "--algorithms"])
    {
        Description = "Specify the hashing algorithms (md5, sha1, sha256, sha384 or sha512)",
        IsRequired = true,
        Arity = ArgumentArity.OneOrMore,
        AllowMultipleArgumentsPerToken = true,
    };

    private readonly Option<string> compareOption = new(["-c", "--compare"])
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

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="RootCommand"/> class.
    /// </summary>
    public RootCommand()
        : base("A cross-platform, command-line interface, checksum utility")
    {
        this.AddArgument(this.inputArgument);

        this.AddOption(this.algorithmsOption);

        this.AddOption(this.compareOption);

        this.AddOption(this.jsonOption);

        this.AddValidator(
            (result) =>
            {
                string? compare = result.GetValueForOption(this.compareOption);

                bool json = result.GetValueForOption(this.jsonOption);

                if (compare is not null && json)
                {
                    result.ErrorMessage = "Options '--compare' and '--json' cannot be used together.";
                }
            });

        this.SetHandler(
            (context) =>
            {
                RootArguments args = new()
                {
                    Input = context.ParseResult.GetValueForArgument(this.inputArgument),
                    Algorithms = context.ParseResult.GetValueForOption(this.algorithmsOption)!,
                    Checksum = context.ParseResult.GetValueForOption(this.compareOption),
                    Json = context.ParseResult.GetValueForOption(this.jsonOption),
                };

                RootHandler.Handle(args, context.Console);
            });
    }

    #endregion
}