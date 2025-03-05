namespace Hashx.Application;

using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.CommandLine;
using System.Diagnostics.CodeAnalysis;
using Hashx.Library;

/// <summary>
/// Defines the <see cref="RootCommand"/> handler.
/// </summary>
internal static class RootHandler
{
    #region Internal Methods

    /// <summary>
    /// Handles the <see cref="RootCommand"/>.
    /// </summary>
    /// <param name="args">The arguments.</param>
    /// <param name="console">The console.</param>
    /// <returns>The exit code.</returns>
    [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Ensures graceful error handling.")]
    internal static int Handle(RootArguments args, IConsole console)
    {
        try
        {
            IReadOnlyCollection<HashingResult> results = GetResults(args.Input, args.Algorithms);

            if (args.Json)
            {
                PrintResultsAsJson(args.Input, results, console);
            }
            else
            {
                PrintResults(results, console);

                if (!string.IsNullOrWhiteSpace(args.Checksum))
                {
                    PrintComparison(results, args.Checksum, console);
                }
            }

            return 0;
        }
        catch (Exception e)
        {
            console.WriteError($"An error occurred: {e.Message}.");

            return 1;
        }
    }

    #endregion

    #region Private Methods

    private static ReadOnlyCollection<HashingResult> GetResults(FileInfo input, IEnumerable<HashingAlgorithm> algorithms)
    {
        IEnumerable<IHashingService> services = algorithms.Select(HashingServiceFactory.GetInstance);

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

    private static void PrintComparison(IReadOnlyCollection<HashingResult> results, string checksum, IConsole console)
    {
        HashingResult? match = results.FirstOrDefault(result => result.Value.Equals(checksum, StringComparison.OrdinalIgnoreCase));

        if (match is not null)
        {
            console.WriteSuccess($"{match.Algorithm} result matches the checksum.");
        }
        else
        {
            console.WriteError("No result matches the checksum.");
        }
    }

    private static void PrintResults(IReadOnlyCollection<HashingResult> results, IConsole console)
    {
        if (results.Count == 1)
        {
            console.Write(results.First().Value);
        }
        else
        {
            foreach (HashingResult result in results)
            {
                console.Write($"{result.Algorithm}\t{result.Value}");
            }
        }
    }

    private static void PrintResultsAsJson(FileInfo input, IReadOnlyCollection<HashingResult> results, IConsole console)
    {
        ExportableResult exportableResult = new(input, results);

        string json = JsonSerializer.Serialize(exportableResult);

        console.Write(json);
    }

    #endregion
}