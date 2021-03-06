namespace Hashx.Application.Handlers
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.CommandLine;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Hashx.Application.Commands;
    using Hashx.Application.Extensions;
    using Hashx.Library.Contracts;
    using Hashx.Library.Hashing;
    using Hashx.Library.Models;
    using Hashx.Library.Serializers;

    /// <summary>
    /// Defines the <see cref="RootCommand"/> handler.
    /// </summary>
    internal static class RootHandler
    {
        #region Internal Methods

        /// <summary>
        /// Handles the <see cref="RootCommand"/>.
        /// </summary>
        /// <param name="input">The input argument.</param>
        /// <param name="algorithms">The algorithms option.</param>
        /// <param name="compare">The compare option.</param>
        /// <param name="json">The JSON option.</param>
        /// <param name="xml">The XML option.</param>
        /// <param name="console">The console.</param>
        /// <returns>The operation result code.</returns>
        internal static int Handle(FileInfo input, string[] algorithms, string compare, bool json, bool xml, IConsole console)
        {
            try
            {
                IEnumerable<IHash> hashAlgos = InitHashAlgos();

                IEnumerable<HashResult> hashes = ComputeHashes(hashAlgos, input, algorithms);

                if (json)
                {
                    PrintResultsAsJson(input, hashes, console);

                    return 0;
                }

                if (xml)
                {
                    PrintResultsAsXml(input, hashes, console);

                    return 0;
                }

                PrintResults(hashes, console);

                if (!string.IsNullOrEmpty(compare))
                {
                    PrintComparison(hashes, compare, console);
                }

                return 0;
            }
            catch (ArgumentException e)
            {
                console.WriteError(e.Message);

                return 1;
            }
        }

        #endregion

        #region Private Methods

        private static IEnumerable<HashResult> ComputeHashes(IEnumerable<IHash> hashAlgos, FileInfo input, ICollection<string> algoNames)
        {
            IEnumerable<IHash> targetHashAlgos = GetTargetHashAlgos(hashAlgos, algoNames);

            ConcurrentBag<HashResult> results = new ();

            Parallel.ForEach(targetHashAlgos, (targetHashAlgo) =>
            {
                HashResult result = targetHashAlgo.GetHash(input);

                results.Add(result);
            });

            return results;
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

        private static void PrintComparison(IEnumerable<HashResult> hashes, string compare, IConsole console)
        {
            foreach (HashResult hash in hashes)
            {
                if (hash.Value.Equals(compare, StringComparison.OrdinalIgnoreCase))
                {
                    console.WriteSuccess($"{hash.Algorithm} checksum matches the specified checksum.");

                    return;
                }
            }

            console.WriteError($"No checksum matches the specified checksum.");
        }

        private static void PrintResults(IEnumerable<HashResult> hashes, IConsole console)
        {
            if (hashes.Count() == 1)
            {
                console.Write(hashes.First().Value);

                return;
            }

            foreach (HashResult hash in hashes)
            {
                console.Write($"{hash.Algorithm}\t{hash.Value}");
            }
        }

        private static void PrintResultsAsJson(FileInfo input, IEnumerable<HashResult> hashes, IConsole console)
        {
            ExportableResult result = new (input, hashes);

            string json = JsonSerializer.Serialize(result);

            console.Write(json);
        }

        private static void PrintResultsAsXml(FileInfo input, IEnumerable<HashResult> hashes, IConsole console)
        {
            ExportableResult result = new (input, hashes);

            string xml = XmlSerializer.Serialize(result);

            console.Write(xml);
        }

        #endregion
    }
}