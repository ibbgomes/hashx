namespace Hashx.Library;

using System.Buffers;

/// <summary>
/// Defines a implementation of <see cref="IMultiHashingService"/>.
/// </summary>
/// <seealso cref="IMultiHashingService"/>
public sealed class MultiHashingService : IMultiHashingService
{
    private const int BufferLength = 128 * 1024;

    /// <inheritdoc/>
    public IReadOnlyCollection<HashingResult> GetHashes(Stream stream, params IEnumerable<HashingAlgorithm> algorithms)
    {
        IHashingService[] services = algorithms
            .Distinct()
            .Select(HashingServiceFactory.Create)
            .ToArray();

        byte[] buffer = ArrayPool<byte>.Shared.Rent(BufferLength);

        try
        {
            while (stream.Read(buffer) is int bytesRead and not 0)
            {
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
            ArrayPool<byte>.Shared.Return(buffer);

            foreach (IHashingService service in services)
            {
                service.Dispose();
            }
        }
    }
}