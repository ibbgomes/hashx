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
                Handler = CommandHandler.Create<FileInfo, string[], string, FileInfo, IConsole>(RootHandler.Handle),
            };

            this.AddCommandArguments();

            this.AddCommandOptions();
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
            };

            this.Command.AddArgument(input);
        }

        private void AddCommandOptions()
        {
            Option<string[]> algorithms = new Option<string[]>(new[] { "-a", "--algorithms" })
            {
                Description = "Define the hashing algorithms used to generate the checksums. Supports MD5, SHA1, SHA256, SHA384 and SHA512",
                IsRequired = true,
            };

            Option<string> compare = new Option<string>(new[] { "-c", "--compare" })
            {
                Description = "Compare the generated checksums against the specified checksum",
                IsRequired = false,
            };

            Option<FileInfo> output = new Option<FileInfo>(new[] { "-o", "--output" })
            {
                Description = "Output the generated checksums to the specified path. Supports JSON, XML and plain-text",
                IsRequired = false,
            };

            this.Command.AddOption(algorithms);
            this.Command.AddOption(compare);
            this.Command.AddOption(output);
        }

        #endregion
    }
}