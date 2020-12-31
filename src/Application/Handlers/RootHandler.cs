namespace Hashx.Application.Handlers
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.CommandLine;
    using System.CommandLine.IO;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Hashx.Application.Commands;
    using Hashx.Library.Contracts;
    using Hashx.Library.Exporting;
    using Hashx.Library.Hashing;
    using Hashx.Library.Models;

    /// <summary>
    /// Defines the <see cref="RootCmd"/> handler.
    /// </summary>
    internal static class RootHandler
    {
        #region Constants

        /// <summary>
        /// The valid algorithm name reg-ex pattern.
        /// </summary>
        private const string ValidAlgoNamePattern = @"^[\w\d]+$";

        #endregion

        #region Internal Methods

        /// <summary>
        /// Handles the <see cref="RootCmd"/>.
        /// </summary>
        /// <param name="input">The input argument.</param>
        /// <param name="algorithms">The algorithms option.</param>
        /// <param name="compare">The compare option.</param>
        /// <param name="output">The output option.</param>
        /// <param name="console">The console.</param>
        /// <returns>The operation result code.</returns>
        internal static int Handle(FileInfo input, string[] algorithms, string compare, FileInfo output, IConsole console)
        {
            try
            {
                IEnumerable<IHash> hashAlgos = InitHashAlgos();

                IEnumerable<HashResult> results = ComputeHashes(hashAlgos, input, algorithms);

                if (output != null)
                {
                    WriteResults(input, results, output);
                }

                PrintResults(results, console);

                if (!string.IsNullOrEmpty(compare))
                {
                    PrintComparison(results, compare, console);
                }

                return 0;
            }
            catch (ArgumentException e)
            {
                console.Error.WriteLine(e.Message);

                return 1;
            }
            catch (FileNotFoundException)
            {
                console.Error.WriteLine("The specified file was not found. Aborting.");

                return 1;
            }
        }

        #endregion

        #region Private Methods

        private static IEnumerable<HashResult> ComputeHashes(IEnumerable<IHash> hashAlgos, FileInfo input, ICollection<string> algoNames)
        {
            ValidateAlgoNames(hashAlgos, algoNames);

            IEnumerable<IHash> targetHashAlgos = GetTargetHashAlgos(hashAlgos, algoNames);

            ConcurrentBag<HashResult> results = new ConcurrentBag<HashResult>();

            Parallel.ForEach(targetHashAlgos, (targetHashAlgo) =>
            {
                HashResult result = targetHashAlgo.GetHash(input);

                results.Add(result);
            });

            return results;
        }

        private static IExporter GetExporter(string fileExtension)
        {
            if (fileExtension.Equals(".json", StringComparison.OrdinalIgnoreCase))
            {
                return new JsonExporter();
            }

            if (fileExtension.Equals(".xml", StringComparison.OrdinalIgnoreCase))
            {
                return new XmlExporter();
            }

            if (fileExtension.Equals(".txt", StringComparison.OrdinalIgnoreCase))
            {
                return new PlainTextExporter();
            }

            throw new ArgumentException($"The specified output path extension '{fileExtension}' is not supported. Aborting.");
        }

        private static IEnumerable<IHash> GetTargetHashAlgos(IEnumerable<IHash> hashAlgos, IEnumerable<string> algoNames)
        {
            ICollection<IHash> targetHashAlgos = new List<IHash>();

            foreach (IHash hashAlgo in hashAlgos)
            {
                foreach (string algoName in algoNames)
                {
                    if (hashAlgo.Name.Equals(algoName, StringComparison.OrdinalIgnoreCase))
                    {
                        targetHashAlgos.Add(hashAlgo);
                    }
                }
            }

            return targetHashAlgos;
        }

        private static IEnumerable<IHash> InitHashAlgos()
        {
            return new List<IHash>()
            {
                new Md5Hash(),
                new Sha1Hash(),
                new Sha256Hash(),
                new Sha384Hash(),
                new Sha512Hash(),
            };
        }

        private static void PrintComparison(IEnumerable<HashResult> hashResults, string compare, IConsole console)
        {
            foreach (HashResult hashResult in hashResults)
            {
                if (hashResult.Value.Equals(compare, StringComparison.OrdinalIgnoreCase))
                {
                    console.Out.WriteLine($"{hashResult.Algorithm} checksum matches the specified checksum.");

                    return;
                }
            }

            console.Out.WriteLine($"No checksum matches the specified checksum.");
        }

        private static void PrintResults(IEnumerable<HashResult> hashResults, IConsole console)
        {
            if (hashResults.Count() == 1)
            {
                console.Out.WriteLine(hashResults.First().Value);

                return;
            }

            foreach (HashResult hashResult in hashResults)
            {
                console.Out.WriteLine($"{hashResult.Algorithm}\t{hashResult.Value}");
            }
        }

        private static void ValidateAlgoNames(IEnumerable<IHash> hashAlgos, IEnumerable<string> algoNames)
        {
            foreach (string algoName in algoNames)
            {
                if (!Regex.IsMatch(algoName, ValidAlgoNamePattern))
                {
                    throw new ArgumentException($"The specified '{algoName}' algorithm is invalid. Algorithms must be alphanumeric. Aborting.");
                }

                if (!hashAlgos.Any(x => x.Name.Equals(algoName, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new ArgumentException($"The specified '{algoName}' algorithm is not supported. Aborting.");
                }
            }
        }

        private static void WriteResults(FileInfo input, IEnumerable<HashResult> hashResults, FileInfo output)
        {
            ExportableResult exportableResult = new ExportableResult(input, hashResults);

            IExporter exporter = GetExporter(output.Extension);

            exporter.Export(exportableResult, output.FullName);
        }

        #endregion
    }
}