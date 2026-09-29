using BenchmarkDotNet.Attributes;
using Hashx.Library;

namespace Hashx.Benchmarks;

/// <summary>
/// Defines benchmarks for <see cref="MultiHashingService"/>.
/// </summary>
[MemoryDiagnoser, ThreadingDiagnoser]
public class MultiHashingServiceBenchmark
{
    private const int size = 32 * 1024 * 1024;

    private readonly string path = Path.GetRandomFileName();

    private readonly MultiHashingService service = new();

    private FileStream stream = null!;

    /// <summary>
    /// Cleans up the benchmark.
    /// </summary>
    [GlobalCleanup]
    public void GlobalCleanup() => File.Delete(path);

    /// <summary>
    /// Sets up the benchmark.
    /// </summary>
    [GlobalSetup]
    public void GlobalSetup()
    {
        byte[] data = new byte[size];

        Random.Shared.NextBytes(data);

        File.WriteAllBytes(path, data);
    }

    /// <summary>
    /// Cleans up the iteration.
    /// </summary>
    [IterationCleanup]
    public void IterationCleanup() => stream.Dispose();

    /// <summary>
    /// Sets up the iteration.
    /// </summary>
    [IterationSetup]
    public void IterationSetup()
    {
        FileStreamOptions options = new()
        {
            Options = FileOptions.SequentialScan,
            BufferSize = 0
        };

        stream = new(path, options);
    }

    /// <summary>
    /// Benchmarks multiple algorithms.
    /// </summary>
    [Benchmark]
    public IReadOnlyCollection<HashingResult> MultipleAlgorithms() => service.GetHashes(stream, HashingAlgorithm.SHA256, HashingAlgorithm.SHA384, HashingAlgorithm.SHA512);

    /// <summary>
    /// Benchmarks a single algorithm.
    /// </summary>
    [Benchmark]
    public IReadOnlyCollection<HashingResult> SingleAlgorithm() => service.GetHashes(stream, HashingAlgorithm.SHA256);
}