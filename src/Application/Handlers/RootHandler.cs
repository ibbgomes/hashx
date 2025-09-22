namespace Hashx.Application;

using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using Hashx.Library;

/// <summary>
/// Defines the <see cref="RootCommand"/> handler.
/// </summary>
internal static class RootHandler
{
    /// <summary>
    /// Handles the <see cref="RootCommand"/>.
    /// </summary>
    /// <param name="args">The arguments.</param>
    /// <returns>The exit code.</returns>
    internal static int Handle(RootArguments args)
    {
        try
        {
            IReadOnlyCollection<HashingResult> results = GetResults(args.Input, args.Algorithms);

            if (args.Json)
            {
                PrintResultsAsJson(args.Input, results);

                return 0;
            }

            PrintResults(results);

            if (!string.IsNullOrWhiteSpace(args.Checksum))
            {
                HashingResult? match = results.FirstOrDefault(r => r.Value.Equals(args.Checksum, StringComparison.OrdinalIgnoreCase));

                PrintMatch(match);

                if (match is null)
                {
                    return 2;
                }
            }

            return 0;
        }
        catch (Exception e)
        {
            ConsoleWriter.WriteErrorLine($"An error occurred: {e.Message}.");

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

    private static void PrintMatch(HashingResult? match)
    {
        if (match is not null)
        {
            ConsoleWriter.WriteSuccessLine($"{match.Algorithm} result matches the checksum.");

            return;
        }

        ConsoleWriter.WriteErrorLine("No result matches the checksum.");
    }

    private static void PrintResults(IReadOnlyCollection<HashingResult> results)
    {
        if (results.Count == 1)
        {
            ConsoleWriter.WriteLine(results.First().Value);

            return;
        }

        foreach (HashingResult result in results)
        {
            ConsoleWriter.WriteLine($"{result.Algorithm}\t{result.Value}");
        }
    }

    private static void PrintResultsAsJson(FileInfo input, IReadOnlyCollection<HashingResult> results)
    {
        ExportableResult exportableResult = new(input, results);

        string json = JsonSerializer.Serialize(exportableResult);

        ConsoleWriter.WriteLine(json);
    }
}