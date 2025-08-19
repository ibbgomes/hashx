namespace Hashx.Application;

using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
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
    [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Ensures graceful error handling.")]
    internal static int Handle(RootArguments args)
    {
        try
        {
            IReadOnlyCollection<HashingResult> results = GetResults(args.Input, args.Algorithms);

            if (args.Json)
            {
                PrintResultsAsJson(args.Input, results);
            }
            else
            {
                PrintResults(results);

                if (!string.IsNullOrWhiteSpace(args.Checksum))
                {
                    return HandleComparison(results, args.Checksum);
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
            .Select(HashingServiceFactory.GetInstance);

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

    private static int HandleComparison(IReadOnlyCollection<HashingResult> results, string checksum)
    {
        HashingResult? match = results.FirstOrDefault(r => r.Value.Equals(checksum, StringComparison.OrdinalIgnoreCase));

        if (match is null)
        {
            ConsoleWriter.WriteErrorLine("No result matches the checksum.");

            return 2;
        }

        ConsoleWriter.WriteSuccessLine($"{match.Algorithm} result matches the checksum.");

        return 0;
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