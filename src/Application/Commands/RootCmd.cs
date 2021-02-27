namespace Hashx.Application.Commands
{
    using System.CommandLine;
    using System.CommandLine.Invocation;
    using System.IO;
    using Hashx.Application.Handlers;

    /// <summary>
    /// Defines the root command.
    /// </summary>
    /// <seealso cref="Hashx.Application.Commands.CmdBase"/>
    internal sealed class RootCmd : CmdBase
    {
        #region Fields

        private readonly string[] algorithms = { "md5", "sha1", "sha256", "sha384", "sha512" };

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RootCmd"/> class.
        /// </summary>
        public RootCmd()
            : base()
        {
            this.Command = new RootCommand()
            {
                Description = "A multi-platform, command line interface, checksum utility",
                Handler = CommandHandler.Create<FileInfo, string[], string, bool, bool, IConsole>(RootHandler.Handle),
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
            Option<string[]> algorithms = new Option<string[]>(new[] { "-a", "--algorithm" })
            {
                Description = "Define a hashing algorithm used to generate the checksums",
                IsRequired = true,
            }.FromAmong(this.algorithms);

            Option<string> compare = new Option<string>(new[] { "-c", "--compare" })
            {
                Description = "Compare the generated checksums against the specified checksum",
                IsRequired = false,
            };

            Option json = new Option<bool>("--json")
            {
                Description = "Output the generated checksums as JSON",
                IsRequired = false,
            };

            Option xml = new Option<bool>("--xml")
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