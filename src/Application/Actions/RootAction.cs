namespace Hashx.Application;

using System.CommandLine;
using System.CommandLine.Invocation;
using System.Text.Json;
using Hashx.Library;

/// <summary>
/// Defines the <see cref="RootCommand"/> action.
/// </summary>
/// <seealso cref="SynchronousCommandLineAction"/>
internal sealed class RootAction : SynchronousCommandLineAction
{
    /// <inheritdoc/>
    public override int Invoke(ParseResult parseResult)
    {
        InvocationContext context = new(parseResult);

        RootArguments arguments = new(parseResult);

        try
        {
            using Stream stream = GetInputStream(arguments.Input);

            ChecksumService checksumService = new();

            IReadOnlyCollection<HashingResult> results = checksumService.GetChecksums(stream, arguments.Algorithms);

            if (arguments.Json)
            {
                PrintResultsAsJson(context.Output, arguments.Input, results);

                return ExitCodes.Success;
            }

            PrintResults(context.Output, results);

            if (!string.IsNullOrWhiteSpace(arguments.Checksum))
            {
                HashingResult? match = results.FirstOrDefault(r => r.Value.Equals(arguments.Checksum, StringComparison.OrdinalIgnoreCase));

                PrintMatch(context.Output, context.Error, match);

                if (match is null)
                {
                    return ExitCodes.ChecksumMismatch;
                }
            }

            return ExitCodes.Success;
        }
        catch (Exception e)
        {
            context.Error.WriteLine($"An error occurred: {e.Message}");

            return ExitCodes.ProcessingError;
        }
    }

    private static Stream GetInputStream(FileInfo? input)
    {
        if (input is not null)
        {
            return input.OpenRead();
        }

        if (Console.IsInputRedirected)
        {
            return Console.OpenStandardInput();
        }

        throw new InvalidOperationException("No input was provided.");
    }

    private static void PrintMatch(TextWriter outputWriter, TextWriter errorWriter, HashingResult? match)
    {
        if (match is not null)
        {
            outputWriter.WriteLine($"{match.Algorithm} result matches the checksum.");

            return;
        }

        errorWriter.WriteLine("No result matches the checksum.");
    }

    private static void PrintResults(TextWriter outputWriter, IReadOnlyCollection<HashingResult> results)
    {
        if (results.Count == 1)
        {
            outputWriter.WriteLine(results.First().Value);

            return;
        }

        int width = results.Max(r => r.Algorithm.ToString().Length) + Formatting.Padding;

        foreach (HashingResult result in results)
        {
            outputWriter.WriteLine(result.Algorithm.ToString().PadRight(width) + result.Value);
        }
    }

    private static void PrintResultsAsJson(TextWriter outputWriter, FileInfo? input, IReadOnlyCollection<HashingResult> results)
    {
        ExportableResult exportableResult = new(input, results);

        string json = JsonSerializer.Serialize(exportableResult, SourceGenerationContext.Default.ExportableResult);

        outputWriter.WriteLine(json);
    }
}