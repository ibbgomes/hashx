namespace Hashx.Application;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
    internal static int Handle(RootArguments args, IConsole console)
    {
        try
        {
            IReadOnlyCollection<HashingResult> results = GetResults(args.Input, args.Algorithms);

            if (args.Json)
            {
                PrintResultsAsJson(args.Input, results, console);

                return 0;
            }

            if (args.Xml)
            {
                PrintResultsAsXml(args.Input, results, console);

                return 0;
            }

            PrintResults(results, console);

            if (!string.IsNullOrEmpty(args.Checksum))
            {
                PrintComparison(results, args.Checksum, console);
            }

            return 0;
        }
        catch (InvalidOperationException e)
        {
            console.WriteError(e.Message);

            return 1;
        }
    }

    #endregion

    #region Private Methods

    private static IEnumerable<IHashingService> GetHashingServices(IEnumerable<HashingAlgorithm> algorithms)
    {
        List<IHashingService> services = new();

        foreach (HashingAlgorithm algorithm in algorithms)
        {
            IHashingService service = HashingServiceFactory.GetInstance(algorithm);

            services.Add(service);
        }

        return services;
    }

    private static IReadOnlyCollection<HashingResult> GetResults(FileInfo input, IEnumerable<HashingAlgorithm> algorithms)
    {
        IEnumerable<IHashingService> services = GetHashingServices(algorithms);

        ConcurrentBag<HashingResult> results = new();

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
        foreach (HashingResult result in results)
        {
            if (result.Value.Equals(checksum, StringComparison.OrdinalIgnoreCase))
            {
                console.WriteSuccess($"{result.Algorithm} result matches the checksum.");

                return;
            }
        }

        console.WriteError("No result matches the checksum.");
    }

    private static void PrintResults(IReadOnlyCollection<HashingResult> hashes, IConsole console)
    {
        if (hashes.Count is 1)
        {
            console.Write(hashes.First().Value);

            return;
        }

        foreach (HashingResult hash in hashes)
        {
            console.Write($"{hash.Algorithm}\t{hash.Value}");
        }
    }

    private static void PrintResultsAsJson(FileInfo input, IReadOnlyCollection<HashingResult> results, IConsole console)
    {
        ExportableResult exportableResult = new(input, results);

        string json = JsonSerializer.Serialize(exportableResult);

        console.Write(json);
    }

    private static void PrintResultsAsXml(FileInfo input, IReadOnlyCollection<HashingResult> results, IConsole console)
    {
        ExportableResult exportableResult = new(input, results);

        string xml = XmlSerializer.Serialize(exportableResult);

        console.Write(xml);
    }

    #endregion
}