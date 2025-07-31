namespace Hashx.Library.Tests;

using FluentAssertions;
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
        const HashingAlgorithm algorithm = (HashingAlgorithm)5;

        Action action = () => HashingServiceFactory.GetInstance(algorithm);

        action.Should().Throw<InvalidOperationException>();
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
    public void HashingServiceFactory_GetInstance_Expected(HashingAlgorithm algorithm)
    {
        IHashingService service = HashingServiceFactory.GetInstance(algorithm);

        service.Algorithm.Should().Be(algorithm);
    }
}