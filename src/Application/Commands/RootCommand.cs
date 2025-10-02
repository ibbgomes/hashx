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
    internal static readonly Option<HashingAlgorithm[]> AlgorithmsOption = new("--algorithms", "-a")
    {
        Description = "Set the hashing algorithms",
        Required = true,
        Arity = ArgumentArity.OneOrMore,
        AllowMultipleArgumentsPerToken = true,
    };

    internal static readonly Option<string> CompareOption = new("--compare", "-c")
    {
        Description = "Compare results against a checksum",
        Required = false,
    };

    internal static readonly Argument<FileInfo> InputArgument = new Argument<FileInfo>("input")
    {
        Description = "Path to the input file",
        Arity = ArgumentArity.ExactlyOne,
    }.AcceptExistingOnly();

    internal static readonly Option<bool> JsonOption = new("--json")
    {
        Description = "Output results in JSON",
        Required = false,
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="RootCommand"/> class.
    /// </summary>
    public RootCommand()
        : base("A cross-platform, command-line interface, checksum utility")
    {
        this.Arguments.Add(InputArgument);

        this.Options.Add(AlgorithmsOption);

        this.Options.Add(CompareOption);

        this.Options.Add(JsonOption);

        this.Validators.Add(
            (result) =>
            {
                string? compare = result.GetValue(CompareOption);

                bool json = result.GetValue(JsonOption);

                if (compare is not null && json)
                {
                    result.AddError("Options '--compare' and '--json' cannot be used together.");
                }
            });

        this.SetAction((result) => new RootAction().Invoke(result));

        foreach (Option option in this.Options)
        {
            if (option is HelpOption { Action: HelpAction helpAction })
            {
                option.Action = new CustomHelpAction(helpAction);

                break;
            }
        }
    }
}