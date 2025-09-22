namespace Hashx.Library;

using System.IO.Hashing;

/// <summary>
/// Defines a non-cryptographic implementation of <see cref="IHashingService"/>
/// </summary>
/// <seealso cref="IHashingService"/>
internal sealed class NonCryptographicHashingService(HashingAlgorithm algorithm, NonCryptographicHashAlgorithm implementation) : IHashingService
{
    private readonly NonCryptographicHashAlgorithm implementation = implementation;

    public HashingAlgorithm Algorithm => algorithm;

    public HashingResult GetHash(FileInfo fileInfo)
    {
        using FileStream fileStream = new(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);

        this
            .implementation
            .Append(fileStream);

        string hash = this
            .implementation
            .GetCurrentHash()
            .ToHexString();

        return new(this.Algorithm, hash);
    }
}