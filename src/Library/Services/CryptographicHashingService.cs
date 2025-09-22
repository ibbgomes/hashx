namespace Hashx.Library;

using System.Security.Cryptography;

/// <summary>
/// Defines a cryptographic implementation of <see cref="IHashingService"/>.
/// </summary>
/// <seealso cref="IHashingService"/>
internal sealed class CryptographicHashingService(HashingAlgorithm algorithm, HashAlgorithm implementation) : IHashingService
{
    private readonly HashAlgorithm implementation = implementation;

    public HashingAlgorithm Algorithm => algorithm;

    public HashingResult GetHash(FileInfo fileInfo)
    {
        using FileStream fileStream = new(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);

        string hash = this
            .implementation
            .ComputeHash(fileStream)
            .ToHexString();

        return new(this.Algorithm, hash);
    }
}