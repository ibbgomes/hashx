namespace Hashx.Application;

using System.CommandLine;
using System.CommandLine.Help;
using Hashx.Library;

/// <summary>
/// Defines the root command.
/// </summary>
/// <seealso cref="System.CommandLine.RootCommand"/>
internal sealed class RootCommand : System.CommandLine.RootCommand
{
    private readonly Option<HashingAlgorithm[]> algorithmsOption = new("--algorithms", "-a")
    {
        Description = "Specify the hashing algorithms",
        Required = true,
        Arity = ArgumentArity.OneOrMore,
        AllowMultipleArgumentsPerToken = true,
    };

    private readonly Option<string> compareOption = new("--compare", "-c")
    {
        Description = "Compare the results against a checksum",
        Required = false,
    };

    private readonly Argument<FileInfo> inputArgument = new Argument<FileInfo>("input")
    {
        Description = "Specify the input file path",
        Arity = ArgumentArity.ExactlyOne,
    }.AcceptExistingOnly();

    private readonly Option<bool> jsonOption = new("--json")
    {
        Description = "Print the results in JSON format",
        Required = false,
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="RootCommand"/> class.
    /// </summary>
    public RootCommand()
        : base("A cross-platform, command-line interface, checksum utility")
    {
        this.Arguments.Add(this.inputArgument);

        this.Options.Add(this.algorithmsOption);

        this.Options.Add(this.compareOption);

        this.Options.Add(this.jsonOption);

        this.Validators.Add(
            (result) =>
            {
                string? compare = result.GetValue(this.compareOption);

                bool json = result.GetValue(this.jsonOption);

                if (compare is not null && json)
                {
                    result.AddError("Options '--compare' and '--json' cannot be used together.");
                }
            });

        this.SetAction(
            (result) =>
            {
                RootArguments args = new()
                {
                    Input = result.GetRequiredValue(this.inputArgument),
                    Algorithms = result.GetRequiredValue(this.algorithmsOption),
                    Checksum = result.GetValue(this.compareOption),
                    Json = result.GetValue(this.jsonOption),
                };

                return RootHandler.Handle(args);
            });

        foreach (Option option in this.Options)
        {
            if (option is HelpOption { Action: HelpAction helpAction })
            {
                option.Action = new CustomAction(helpAction);

                break;
            }
        }
    }
}