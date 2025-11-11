namespace Hashx.Library.Tests;

using Xunit;

/// <summary>
/// Defines unit tests for <see cref="CryptographicHashingServiceFactory"/>.
/// </summary>
public sealed class CryptographicHashingServiceFactoryTests
{
    /// <summary>
    /// Tests that <see cref="CryptographicHashingServiceFactory.Create(HashingAlgorithm)"/> returns the expected <see cref="CryptographicHashingService"/>.
    /// </summary>
    [Theory]
    [InlineData(HashingAlgorithm.MD5)]
    [InlineData(HashingAlgorithm.SHA1)]
    [InlineData(HashingAlgorithm.SHA256)]
    [InlineData(HashingAlgorithm.SHA384)]
    [InlineData(HashingAlgorithm.SHA512)]
    [InlineData(HashingAlgorithm.SHA3_256)]
    [InlineData(HashingAlgorithm.SHA3_384)]
    [InlineData(HashingAlgorithm.SHA3_512)]
    public void CryptographicHashingServiceFactory_Create_Expected(HashingAlgorithm algorithm)
    {
        CryptographicHashingService service = CryptographicHashingServiceFactory.Create(algorithm);

        Assert.Equal(algorithm, service.Algorithm);
    }
}