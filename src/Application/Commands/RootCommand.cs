namespace Hashx.Application.Commands
{
    using System.CommandLine;
    using System.CommandLine.Invocation;
    using System.IO;
    using Hashx.Application.Arguments;
    using Hashx.Application.Handlers;

    /// <summary>
    /// Defines the root command.
    /// </summary>
    /// <seealso cref="Hashx.Application.Commands.CommandBase"/>
    internal sealed class RootCommand : CommandBase
    {
        #region Fields

        private readonly string[] algorithms = { "md5", "sha1", "sha256", "sha384", "sha512" };

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RootCommand"/> class.
        /// </summary>
        public RootCommand()
            : base()
        {
            this.Command = new System.CommandLine.RootCommand()
            {
                Description = "A multi-platform, command line interface, checksum utility",
                Handler = CommandHandler.Create(
                    (RootArguments args, IConsole console) => RootHandler.Handle(args, console)),
            };

            this.AddCommandArguments();

            this.AddCommandOptions();

            this.AddCommandValidators();
        }

        #endregion

        #region Private Methods

        private void AddCommandArguments()
        {
            Argument<FileInfo> input = new Argument<FileInfo>()
            {
                Name = "input",
                Description = "The path of the file to be handled",
                Arity = ArgumentArity.ExactlyOne,
            }.ExistingOnly();

            this.Command.AddArgument(input);
        }

        private void AddCommandOptions()
        {
            Option<string[]> algorithms = new Option<string[]>(new[] { "-a", "--algorithms" })
            {
                Description = "Define the hashing algorithms used to generate the checksums",
                IsRequired = true,
            }.FromAmong(this.algorithms);

            Option<string> compare = new (new[] { "-c", "--compare" })
            {
                Description = "Compare the generated checksums against the specified checksum",
                IsRequired = false,
            };

            Option json = new ("--json")
            {
                Description = "Output the generated checksums as JSON",
                IsRequired = false,
            };

            Option xml = new ("--xml")
            {
                Description = "Output the generated checksums as XML",
                IsRequired = false,
            };

            this.Command.AddOption(algorithms);
            this.Command.AddOption(compare);
            this.Command.AddOption(json);
            this.Command.AddOption(xml);
        }

        private void AddCommandValidators()
        {
            this.Command.AddValidator(result =>
            {
                if (result.Children.Contains("--compare") &&
                    result.Children.Contains("--json"))
                {
                    return "Options '--compare' and '--json' cannot be used together.";
                }

                if (result.Children.Contains("--compare") &&
                    result.Children.Contains("--xml"))
                {
                    return "Options '--compare' and '--xml' cannot be used together.";
                }

                if (result.Children.Contains("--json") &&
                    result.Children.Contains("--xml"))
                {
                    return "Options '--json' and '--xml' cannot be used together.";
                }

                return null;
            });
        }

        #endregion
    }
}