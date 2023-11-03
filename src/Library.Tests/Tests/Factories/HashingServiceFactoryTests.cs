namespace Hashx.Library.Tests;

using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;

/// <summary>
/// Defines unit tests for <see cref="HashingServiceFactory"/>.
/// </summary>
[SuppressMessage("Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Unit tests.")]
public sealed class HashingServiceFactoryTests
{
    #region Public Methods

    /// <summary>
    /// Tests that <see cref="HashingServiceFactory.GetInstance(HashingAlgorithm)"/> returns an <see cref="InvalidOperationException"/>.
    /// </summary>
    [Fact]
    public void HashingServiceFactory_GetInstance_Exception()
    {
        HashingAlgorithm algorithm = (HashingAlgorithm)5;

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
        HashingAlgorithm algorithm = HashingAlgorithm.MD5;

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
        HashingAlgorithm algorithm = HashingAlgorithm.SHA1;

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
        HashingAlgorithm algorithm = HashingAlgorithm.SHA256;

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
        HashingAlgorithm algorithm = HashingAlgorithm.SHA384;

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
        HashingAlgorithm algorithm = HashingAlgorithm.SHA512;

        IHashingService service = HashingServiceFactory.GetInstance(algorithm);

        service.Algorithm.Should().Be(algorithm);
    }

    #endregion
}