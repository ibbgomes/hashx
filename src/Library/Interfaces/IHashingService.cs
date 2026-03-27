namespace Hashx.Library;

/// <summary>
/// Defines a service for computing hashes incrementally.
/// </summary>
/// <seealso cref="IDisposable"/>
internal interface IHashingService : IDisposable
{
    /// <summary>
    /// Gets the algorithm used by this service.
    /// </summary>
    HashingAlgorithm Algorithm { get; }

    /// <summary>
    /// Appends the specified data to the hash computation.
    /// </summary>
    /// <param name="data">The data.</param>
    void Append(ReadOnlySpan<byte> data);

    /// <summary>
    /// Gets the <see cref="HashingResult"/> and resets the hash computation.
    /// </summary>
    /// <returns>The hashing result.</returns>
    HashingResult GetHashAndReset();
}