namespace Hashx.Library.Tests;

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Hashx.Library;

/// <summary>
/// Defines helpers used in serialization unit tests.
/// </summary>
internal static class Serialization
{
    #region Internal Methods

    /// <summary>
    /// Gets an <see cref="ExportableResult"/> from the specified <see cref="FileInfo"/>.
    /// </summary>
    /// <param name="fileInfo">The file information.</param>
    /// <returns>The exportable result.</returns>
    internal static ExportableResult GetExportableResult(FileInfo fileInfo)
    {
        IEnumerable<IHashingService> services = GetHashingServices();

        ConcurrentBag<HashingResult> results = new();

        Parallel.ForEach(services, (service) =>
        {
            HashingResult result = service.GetHash(fileInfo);

            results.Add(result);
        });

        return new(fileInfo, results);
    }

    #endregion

    #region Private Methods

    private static IEnumerable<IHashingService> GetHashingServices()
    {
        return new List<IHashingService>()
        {
            new Md5Service(),
            new Sha1Service(),
            new Sha256Service(),
            new Sha384Service(),
            new Sha512Service(),
        };
    }

    #endregion
}