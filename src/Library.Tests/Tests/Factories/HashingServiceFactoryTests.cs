namespace Hashx.Library.Tests;

using Xunit;

/// <summary>
/// Defines unit tests for <see cref="HashingServiceFactory"/>.
/// </summary>
public sealed class HashingServiceFactoryTests
{
    /// <summary>
    /// Tests that <see cref="HashingServiceFactory.GetInstance(HashingAlgorithm)"/> returns an <see cref="InvalidOperationException"/>.
    /// </summary>
    [Fact]
    public void HashingServiceFactory_GetInstance_Exception()
    {
        const HashingAlgorithm algorithm = (HashingAlgorithm)11;

        static void getInstance() => HashingServiceFactory.GetInstance(algorithm);

        Assert.Throws<InvalidOperationException>(getInstance);
    }

    /// <summary>
    /// Tests that <see cref="HashingServiceFactory.GetInstance(HashingAlgorithm)"/> returns the
    /// expected <see cref="IHashingService"/>.
    /// </summary>
    [Theory]
    [InlineData(HashingAlgorithm.MD5)]
    [InlineData(HashingAlgorithm.SHA1)]
    [InlineData(HashingAlgorithm.SHA256)]
    [InlineData(HashingAlgorithm.SHA384)]
    [InlineData(HashingAlgorithm.SHA512)]
    [InlineData(HashingAlgorithm.CRC32)]
    [InlineData(HashingAlgorithm.CRC64)]
    [InlineData(HashingAlgorithm.XXH32)]
    [InlineData(HashingAlgorithm.XXH64)]
    [InlineData(HashingAlgorithm.XXH128)]
    [InlineData(HashingAlgorithm.XXH3)]
    public void HashingServiceFactory_GetInstance_Expected(HashingAlgorithm algorithm)
    {
        IHashingService service = HashingServiceFactory.GetInstance(algorithm);

        Assert.Equal(algorithm, service.Algorithm);
    }
}