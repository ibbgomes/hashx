namespace Hashx.Application.Commands
{
    using System.CommandLine;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the base implementation of a command.
    /// </summary>
    internal abstract class CommandBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBase"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        protected CommandBase()
        {
        }

        #endregion

        #region Protected Properties

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        protected Command Command { get; set; }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Invokes the command asynchronously.
        /// </summary>
        /// <param name="args">The command arguments.</param>
        /// <returns>The command result code.</returns>
        internal virtual async Task<int> InvokeAsync(string[] args)
        {
            return await this.Command.InvokeAsync(args)
                .ConfigureAwait(false);
        }

        #endregion
    }
}