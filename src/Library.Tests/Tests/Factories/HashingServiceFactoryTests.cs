namespace Hashx.Library.Tests;

using FluentAssertions;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="HashingServiceFactory"/>.
/// </summary>
public sealed class HashingServiceFactoryTests
{
    #region Public Methods

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
    [Fact]
    public void HashingServiceFactory_GetInstance_Expected_1()
    {
        const HashingAlgorithm algorithm = HashingAlgorithm.MD5;

        IHashingService service = HashingServiceFactory.GetInstance(algorithm);

        service.Algorithm.Should().Be(algorithm);
    }

    /// <summary>
    /// Tests that <see cref="HashingServiceFactory.GetInstance(HashingAlgorithm)"/> returns the
    /// expected <see cref="IHashingService"/>.
    /// </summary>
    [Fact]
    public void HashingServiceFactory_GetInstance_Expected_2()
    {
        const HashingAlgorithm algorithm = HashingAlgorithm.SHA1;

        IHashingService service = HashingServiceFactory.GetInstance(algorithm);

        service.Algorithm.Should().Be(algorithm);
    }

    /// <summary>
    /// Tests that <see cref="HashingServiceFactory.GetInstance(HashingAlgorithm)"/> returns the
    /// expected <see cref="IHashingService"/>.
    /// </summary>
    [Fact]
    public void HashingServiceFactory_GetInstance_Expected_3()
    {
        const HashingAlgorithm algorithm = HashingAlgorithm.SHA256;

        IHashingService service = HashingServiceFactory.GetInstance(algorithm);

        service.Algorithm.Should().Be(algorithm);
    }

    /// <summary>
    /// Tests that <see cref="HashingServiceFactory.GetInstance(HashingAlgorithm)"/> returns the
    /// expected <see cref="IHashingService"/>.
    /// </summary>
    [Fact]
    public void HashingServiceFactory_GetInstance_Expected_4()
    {
        const HashingAlgorithm algorithm = HashingAlgorithm.SHA384;

        IHashingService service = HashingServiceFactory.GetInstance(algorithm);

        service.Algorithm.Should().Be(algorithm);
    }

    /// <summary>
    /// Tests that <see cref="HashingServiceFactory.GetInstance(HashingAlgorithm)"/> returns the
    /// expected <see cref="IHashingService"/>.
    /// </summary>
    [Fact]
    public void HashingServiceFactory_GetInstance_Expected_5()
    {
        const HashingAlgorithm algorithm = HashingAlgorithm.SHA512;

        IHashingService service = HashingServiceFactory.GetInstance(algorithm);

        service.Algorithm.Should().Be(algorithm);
    }

    #endregion
}