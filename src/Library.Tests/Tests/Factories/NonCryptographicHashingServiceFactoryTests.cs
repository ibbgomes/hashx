namespace Hashx.Library.Tests;

using Xunit;

/// <summary>
/// Defines unit tests for <see cref="NonCryptographicHashingServiceFactory"/>.
/// </summary>
public sealed class NonCryptographicHashingServiceFactoryTests
{
    /// <summary>
    /// Tests that <see cref="NonCryptographicHashingServiceFactory.Create(HashingAlgorithm)"/> returns the expected <see cref="NonCryptographicHashingService"/>.
    /// </summary>
    [Theory]
    [InlineData(HashingAlgorithm.CRC32)]
    [InlineData(HashingAlgorithm.CRC64)]
    [InlineData(HashingAlgorithm.XXH32)]
    [InlineData(HashingAlgorithm.XXH64)]
    [InlineData(HashingAlgorithm.XXH128)]
    [InlineData(HashingAlgorithm.XXH3)]
    public void NonCryptographicHashingServiceFactory_Create_Expected(HashingAlgorithm algorithm)
    {
        NonCryptographicHashingService service = NonCryptographicHashingServiceFactory.Create(algorithm);

        Assert.Equal(algorithm, service.Algorithm);
    }
}