using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Wrapper;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TokenProviderTests
{
    [Test]
    public void TokenProvider_Constructor_ShouldAcceptValidParameters()
    {
        // TokenProvider is internal, so we use reflection to test it
        var tokenProviderType = typeof(ManagementClient).Assembly
            .GetType("Auth0.ManagementApi.TokenProvider")!;

        using var httpClient = new HttpClient();

        // Act - should not throw
        var tokenProvider = Activator.CreateInstance(
            tokenProviderType,
            "tenant.auth0.com",
            "test-client-id",
            "test-client-secret",
            "https://tenant.auth0.com/api/v2/",
            httpClient);

        // Assert
        Assert.That(tokenProvider, Is.Not.Null);
    }

    [Test]
    public void TokenProvider_Constructor_WithNullDomain_ShouldThrow()
    {
        var tokenProviderType = typeof(ManagementClient).Assembly
            .GetType("Auth0.ManagementApi.TokenProvider")!;

        using var httpClient = new HttpClient();

        // Act & Assert
        var ex = Assert.Throws<System.Reflection.TargetInvocationException>(() =>
            Activator.CreateInstance(
                tokenProviderType,
                (string)null!,
                "test-client-id",
                "test-client-secret",
                "https://tenant.auth0.com/api/v2/",
                httpClient));

        Assert.That(ex!.InnerException, Is.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void TokenProvider_Constructor_WithNullClientId_ShouldThrow()
    {
        var tokenProviderType = typeof(ManagementClient).Assembly
            .GetType("Auth0.ManagementApi.TokenProvider")!;

        using var httpClient = new HttpClient();

        // Act & Assert
        var ex = Assert.Throws<System.Reflection.TargetInvocationException>(() =>
            Activator.CreateInstance(
                tokenProviderType,
                "tenant.auth0.com",
                (string)null!,
                "test-client-secret",
                "https://tenant.auth0.com/api/v2/",
                httpClient));

        Assert.That(ex!.InnerException, Is.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void TokenProvider_Constructor_WithNullClientSecret_ShouldThrow()
    {
        var tokenProviderType = typeof(ManagementClient).Assembly
            .GetType("Auth0.ManagementApi.TokenProvider")!;

        using var httpClient = new HttpClient();

        // Act & Assert
        var ex = Assert.Throws<System.Reflection.TargetInvocationException>(() =>
            Activator.CreateInstance(
                tokenProviderType,
                "tenant.auth0.com",
                "test-client-id",
                (string)null!,
                "https://tenant.auth0.com/api/v2/",
                httpClient));

        Assert.That(ex!.InnerException, Is.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void TokenProvider_Constructor_WithNullAudience_ShouldUseDefault()
    {
        var tokenProviderType = typeof(ManagementClient).Assembly
            .GetType("Auth0.ManagementApi.TokenProvider")!;

        using var httpClient = new HttpClient();

        // Act - should not throw when audience is null (uses default)
        var tokenProvider = Activator.CreateInstance(
            tokenProviderType,
            "tenant.auth0.com",
            "test-client-id",
            "test-client-secret",
            (string?)null,
            httpClient);

        // Assert
        Assert.That(tokenProvider, Is.Not.Null);
    }

    [Test]
    public void TokenProvider_Constructor_WithNullHttpClient_ShouldCreateOwn()
    {
        var tokenProviderType = typeof(ManagementClient).Assembly
            .GetType("Auth0.ManagementApi.TokenProvider")!;

        // Act - should not throw when httpClient is null (creates its own)
        var tokenProvider = Activator.CreateInstance(
            tokenProviderType,
            "tenant.auth0.com",
            "test-client-id",
            "test-client-secret",
            "https://tenant.auth0.com/api/v2/",
            (HttpClient?)null);

        // Assert
        Assert.That(tokenProvider, Is.Not.Null);
    }
}
