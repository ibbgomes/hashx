namespace Hashx.Application;

using System.CommandLine;
using System.CommandLine.Invocation;

/// <summary>
/// Defines the context for a <see cref="CommandLineAction"/> invocation.
/// </summary>
internal sealed class InvocationContext(ParseResult parseResult)
{
    /// <summary>
    /// Gets the error text writer.
    /// </summary>
    internal TextWriter Error => parseResult.InvocationConfiguration.Error;

    /// <summary>
    /// Gets the output text writer.
    /// </summary>
    internal TextWriter Output => parseResult.InvocationConfiguration.Output;
}