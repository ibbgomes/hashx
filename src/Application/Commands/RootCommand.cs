using System.CommandLine;
using System.CommandLine.Help;
using Hashx.Library;

namespace Hashx.Application;

/// <summary>
/// Defines the root command.
/// </summary>
/// <seealso cref="System.CommandLine.RootCommand"/>
internal sealed class RootCommand : System.CommandLine.RootCommand
{
    internal static readonly Option<HashingAlgorithm[]> AlgorithmsOption = new("--algorithms", "-a")
    {
        Description = "Set one or more space-separated algorithms",
        HelpName = "list",
        Required = true,
        Arity = ArgumentArity.OneOrMore,
        AllowMultipleArgumentsPerToken = true,
    };

    internal static readonly Option<string> CompareOption = new("--compare", "-c")
    {
        Description = "Compare results against an expected hash",
        HelpName = "hash",
        Required = false,
    };

    internal static readonly Argument<FileInfo> InputArgument = new Argument<FileInfo>("input")
    {
        Description = "Path to the input file. If none, reads from stdin",
        Arity = ArgumentArity.ZeroOrOne,
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
        : base("A cross-platform, command-line interface, hashing utility")
    {
        this.Arguments.Add(InputArgument);

        this.Options.Add(AlgorithmsOption);

        this.Options.Add(CompareOption);

        this.Options.Add(JsonOption);

        this.SetAction(result => new RootAction().Invoke(result));

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