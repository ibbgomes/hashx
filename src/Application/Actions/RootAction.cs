namespace Hashx.Application;

using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.CommandLine;
using System.CommandLine.Invocation;
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

        try
        {
            RootArguments arguments = new(parseResult);

            IReadOnlyCollection<HashingResult> results = GetResults(arguments.Input, arguments.Algorithms);

            if (arguments.Json)
            {
                PrintResultsAsJson(context.Output, arguments.Input, results);

                return 0;
            }

            PrintResults(context.Output, results);

            if (!string.IsNullOrWhiteSpace(arguments.Checksum))
            {
                HashingResult? match = results.FirstOrDefault(r => r.Value.Equals(arguments.Checksum, StringComparison.OrdinalIgnoreCase));

                PrintMatch(context.Output, context.Error, match);

                if (match is null)
                {
                    return 2;
                }
            }

            return 0;
        }
        catch (Exception e)
        {
            context.Output.WriteErrorLine($"An error occurred: {e.Message}.");

            return 1;
        }
    }

    private static ReadOnlyCollection<HashingResult> GetResults(FileInfo input, IEnumerable<HashingAlgorithm> algorithms)
    {
        IEnumerable<IHashingService> services = algorithms
            .Distinct()
            .Select(HashingServiceFactory.Create);

        ConcurrentBag<HashingResult> results = [];

        Parallel.ForEach(services, (service) =>
        {
            HashingResult result = service.GetHash(input);

            results.Add(result);
        });

        return results
            .OrderBy(x => x.Algorithm)
            .ToList()
            .AsReadOnly();
    }

    private static void PrintMatch(TextWriter outputWriter, TextWriter errorWriter, HashingResult? match)
    {
        if (match is not null)
        {
            outputWriter.WriteSuccessLine($"{match.Algorithm} result matches the checksum.");

            return;
        }

        errorWriter.WriteErrorLine("No result matches the checksum.");
    }

    private static void PrintResults(TextWriter outputWriter, IReadOnlyCollection<HashingResult> results)
    {
        if (results.Count == 1)
        {
            outputWriter.WriteLine(results.First().Value);

            return;
        }

        foreach (HashingResult result in results)
        {
            outputWriter.WriteLine($"{result.Algorithm}\t{result.Value}");
        }
    }

    private static void PrintResultsAsJson(TextWriter outputWriter, FileInfo input, IReadOnlyCollection<HashingResult> results)
    {
        ExportableResult exportableResult = new(input, results);

        string json = JsonSerializer.Serialize(exportableResult);

        outputWriter.WriteLine(json);
    }
}