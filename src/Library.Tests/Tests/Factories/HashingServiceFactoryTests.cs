namespace Hashx.Library.Tests;

using Xunit;

/// <summary>
/// Defines unit tests for <see cref="HashingServiceFactory"/>.
/// </summary>
public sealed class HashingServiceFactoryTests
{
    /// <summary>
    /// Tests that <see cref="HashingServiceFactory.Create(HashingAlgorithm)"/> returns a <see cref="NotSupportedException"/>.
    /// </summary>
    [Fact]
    public void HashingServiceFactory_Create_Exception()
    {
        const HashingAlgorithm algorithm = (HashingAlgorithm)14;

        static void create() => HashingServiceFactory.Create(algorithm);

        Assert.Throws<NotSupportedException>(create);
    }

    /// <summary>
    /// Tests that <see cref="HashingServiceFactory.Create(HashingAlgorithm)"/> returns the expected <see cref="IHashingService"/>.
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
    [InlineData(HashingAlgorithm.CRC32)]
    [InlineData(HashingAlgorithm.CRC64)]
    [InlineData(HashingAlgorithm.XXH3)]
    [InlineData(HashingAlgorithm.XXH32)]
    [InlineData(HashingAlgorithm.XXH64)]
    [InlineData(HashingAlgorithm.XXH128)]
    public void HashingServiceFactory_Create_Expected(HashingAlgorithm algorithm)
    {
        IHashingService service = HashingServiceFactory.Create(algorithm);

        Assert.Equal(algorithm, service.Algorithm);
    }
}