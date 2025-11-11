namespace Hashx.Library;

using System.IO.Hashing;

/// <summary>
/// Defines a non-cryptographic implementation of <see cref="IHashingService"/>
/// </summary>
/// <seealso cref="IHashingService"/>
internal sealed class NonCryptographicHashingService(HashingAlgorithm algorithm, NonCryptographicHashAlgorithm implementation) : IHashingService
{
    public HashingAlgorithm Algorithm => algorithm;

    public HashingResult GetHash(FileInfo fileInfo)
    {
        using FileStream stream = new(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);

        implementation.Append(stream);

        string hash = implementation.GetCurrentHash().ToHexString();

        return new(this.Algorithm, hash);
    }
}