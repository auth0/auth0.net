using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Wrapper;

file sealed class TrackingDisposableTokenProvider : ITokenProvider, IDisposable
{
    public bool IsDisposed { get; private set; }
    public Task<string> GetTokenAsync(CancellationToken cancellationToken = default) => Task.FromResult("tracking-token");
    public void Dispose() => IsDisposed = true;
}

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ManagementClientTests
{
    [Test]
    public void Constructor_WithDelegateTokenProvider_ShouldSucceed()
    {
        var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com",
            TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("test-token"))
        });

        Assert.That(client, Is.Not.Null);
        Assert.That(client.Users, Is.Not.Null);
        Assert.That(client.Actions, Is.Not.Null);
    }

    [Test]
    public void Constructor_WithDelegateTokenProvider_NotCalledUntilRequest()
    {
        var callCount = 0;
        var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com",
            TokenProvider = new DelegateTokenProvider(_ =>
            {
                callCount++;
                return Task.FromResult("dynamic-token");
            })
        });

        Assert.That(client, Is.Not.Null);
        // Token provider must not be invoked during construction
        Assert.That(callCount, Is.EqualTo(0));
    }

    [Test]
    public void Constructor_WithClientCredentialsTokenProvider_ShouldSucceed()
    {
        var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com",
            TokenProvider = new ClientCredentialsTokenProvider(
                "tenant.auth0.com", "test-client-id", "test-client-secret")
        });

        Assert.That(client, Is.Not.Null);
        Assert.That(client.Users, Is.Not.Null);
    }

    [Test]
    public void Constructor_WithNullOptions_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => new ManagementClient(null!));
    }

    [Test]
    public void Constructor_WithEmptyDomain_Throws()
    {
        Assert.Throws<ArgumentException>(() => new ManagementClient(new ManagementClientOptions
        {
            Domain = "",
            TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("test-token"))
        }));
    }

    [Test]
    public void Constructor_WithWhitespaceDomain_Throws()
    {
        Assert.Throws<ArgumentException>(() => new ManagementClient(new ManagementClientOptions
        {
            Domain = "   ",
            TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("test-token"))
        }));
    }

    [Test]
    public void Constructor_WithHttpsSchemePrefixedDomain_Throws()
    {
        Assert.Throws<ArgumentException>(() => new ManagementClient(new ManagementClientOptions
        {
            Domain = "https://tenant.auth0.com",
            TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("test-token"))
        }));
    }

    [Test]
    public void Constructor_WithHttpSchemePrefixedDomain_Throws()
    {
        Assert.Throws<ArgumentException>(() => new ManagementClient(new ManagementClientOptions
        {
            Domain = "http://tenant.auth0.com",
            TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("test-token"))
        }));
    }

    [Test]
    public void Constructor_WithAllOptions_ShouldSucceed()
    {
        using var httpClient = new HttpClient();

        var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com",
            TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("test-token")),
            HttpClient = httpClient,
            Timeout = TimeSpan.FromSeconds(60),
            MaxRetries = 5,
            AdditionalHeaders = new Dictionary<string, string>
            {
                { "X-Custom-Header", "custom-value" }
            }
        });

        Assert.That(client, Is.Not.Null);
    }

    [Test]
    public void ManagementClient_ImplementsIManagementApiClient()
    {
        var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com",
            TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("test-token"))
        });

        // ManagementClient must be assignable to the common interface
        IManagementApiClient api = client;
        Assert.That(api, Is.Not.Null);
    }

    [Test]
    public void ManagementClient_Dispose_DoesNotThrow()
    {
        var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com",
            TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("test-token"))
        });

        Assert.DoesNotThrow(() => client.Dispose());
    }

    [Test]
    public void ManagementClient_Dispose_WithExternalHttpClient_DoesNotDisposeIt()
    {
        using var httpClient = new HttpClient();

        var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com",
            TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("test-token")),
            HttpClient = httpClient
        });

        client.Dispose();

        // External HttpClient must still be usable after the client is disposed
        Assert.DoesNotThrow(() => httpClient.CancelPendingRequests());
    }

    [Test]
    public void Constructor_WithNullTokenProvider_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com",
            TokenProvider = null!
        }));
    }

    [Test]
    public void ManagementClient_Dispose_DoesNotDisposeExternalTokenProvider()
    {
        // The caller owns the provider and is responsible for its lifetime.
        // Disposing the client must not dispose a provider it did not create.
        var provider = new TrackingDisposableTokenProvider();
        var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com",
            TokenProvider = provider
        });

        client.Dispose();

        Assert.That(provider.IsDisposed, Is.False);
    }

    [Test]
    public void AllSubClients_ShouldBeAccessible()
    {
        var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com",
            TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("test-token"))
        });

        Assert.Multiple(() =>
        {
            Assert.That(client.Actions, Is.Not.Null);
            Assert.That(client.Branding, Is.Not.Null);
            Assert.That(client.ClientGrants, Is.Not.Null);
            Assert.That(client.Clients, Is.Not.Null);
            Assert.That(client.ConnectionProfiles, Is.Not.Null);
            Assert.That(client.Connections, Is.Not.Null);
            Assert.That(client.CustomDomains, Is.Not.Null);
            Assert.That(client.DeviceCredentials, Is.Not.Null);
            Assert.That(client.EmailTemplates, Is.Not.Null);
            Assert.That(client.EventStreams, Is.Not.Null);
            Assert.That(client.Flows, Is.Not.Null);
            Assert.That(client.Forms, Is.Not.Null);
            Assert.That(client.UserGrants, Is.Not.Null);
            Assert.That(client.Groups, Is.Not.Null);
            Assert.That(client.Hooks, Is.Not.Null);
            Assert.That(client.Jobs, Is.Not.Null);
            Assert.That(client.LogStreams, Is.Not.Null);
            Assert.That(client.Logs, Is.Not.Null);
            Assert.That(client.NetworkAcls, Is.Not.Null);
            Assert.That(client.Organizations, Is.Not.Null);
            Assert.That(client.Prompts, Is.Not.Null);
            Assert.That(client.RefreshTokens, Is.Not.Null);
            Assert.That(client.ResourceServers, Is.Not.Null);
            Assert.That(client.Roles, Is.Not.Null);
            Assert.That(client.Rules, Is.Not.Null);
            Assert.That(client.RulesConfigs, Is.Not.Null);
            Assert.That(client.SelfServiceProfiles, Is.Not.Null);
            Assert.That(client.Sessions, Is.Not.Null);
            Assert.That(client.Stats, Is.Not.Null);
            Assert.That(client.SupplementalSignals, Is.Not.Null);
            Assert.That(client.Tickets, Is.Not.Null);
            Assert.That(client.TokenExchangeProfiles, Is.Not.Null);
            Assert.That(client.UserAttributeProfiles, Is.Not.Null);
            Assert.That(client.UserBlocks, Is.Not.Null);
            Assert.That(client.Users, Is.Not.Null);
            Assert.That(client.Anomaly, Is.Not.Null);
            Assert.That(client.AttackProtection, Is.Not.Null);
            Assert.That(client.Emails, Is.Not.Null);
            Assert.That(client.Guardian, Is.Not.Null);
            Assert.That(client.Keys, Is.Not.Null);
            Assert.That(client.RiskAssessments, Is.Not.Null);
            Assert.That(client.Tenants, Is.Not.Null);
            Assert.That(client.VerifiableCredentials, Is.Not.Null);
        });
    }
}
