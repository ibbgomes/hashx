using System.Buffers;

namespace Hashx.Library;

/// <summary>
/// Defines an implementation of <see cref="IMultiHashingService"/>.
/// </summary>
/// <seealso cref="IMultiHashingService"/>
public sealed class MultiHashingService : IMultiHashingService
{
    private const int BufferSize = 128 * 1024;

    private const int ParallelThreshold = 2;

    /// <inheritdoc/>
    public IReadOnlyCollection<HashingResult> GetHashes(Stream stream, params IEnumerable<HashingAlgorithm> algorithms)
    {
        IHashingService[] services = algorithms
            .Distinct()
            .Select(HashingServiceFactory.Create)
            .ToArray();

        byte[] buffer = ArrayPool<byte>.Shared.Rent(BufferSize);

        try
        {
            while (stream.Read(buffer) is int bytesRead and not 0)
            {
                if (services.Length >= ParallelThreshold)
                {
                    Parallel.ForEach(services, service =>
                    {
                        ReadOnlySpan<byte> data = buffer.AsSpan()[..bytesRead];

                        service.Append(data);
                    });

                    continue;
                }

                ReadOnlySpan<byte> data = buffer.AsSpan()[..bytesRead];

                foreach (IHashingService service in services)
                {
                    service.Append(data);
                }
            }

            return services
                .Select(s => s.GetHashAndReset())
                .OrderBy(r => r.Algorithm)
                .ToArray();
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer, true);

            foreach (IHashingService service in services)
            {
                service.Dispose();
            }
        }
    }
}
