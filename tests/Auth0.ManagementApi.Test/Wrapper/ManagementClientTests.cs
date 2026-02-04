using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Wrapper;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ManagementClientTests
{
    [Test]
    public void Constructor_WithToken_ShouldSucceed()
    {
        var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com",
            Token = "test-token"
        });

        Assert.That(client, Is.Not.Null);
        Assert.That(client.Users, Is.Not.Null);
        Assert.That(client.Actions, Is.Not.Null);
    }

    [Test]
    public void Constructor_WithTokenProvider_ShouldSucceed()
    {
        var callCount = 0;
        var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com",
            TokenProvider = () =>
            {
                callCount++;
                return "dynamic-token";
            }
        });

        Assert.That(client, Is.Not.Null);
        // Token provider is not called until a request is made
        Assert.That(callCount, Is.EqualTo(0));
    }

    [Test]
    public void Constructor_WithClientCredentials_ShouldSucceed()
    {
        var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com",
            ClientId = "test-client-id",
            ClientSecret = "test-client-secret"
        });

        Assert.That(client, Is.Not.Null);
        Assert.That(client.Users, Is.Not.Null);
    }

    [Test]
    public void Constructor_WithCustomAudience_ShouldSucceed()
    {
        var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com",
            ClientId = "test-client-id",
            ClientSecret = "test-client-secret",
            Audience = "https://custom-audience.example.com/"
        });

        Assert.That(client, Is.Not.Null);
    }

    [Test]
    public void Constructor_WithNullOptions_ShouldThrowArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new ManagementClient(null!));
    }

    [Test]
    public void Constructor_WithNoAuth_ShouldThrowArgumentException()
    {
        var ex = Assert.Throws<ArgumentException>(() => new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com"
        }));

        Assert.That(ex!.Message, Does.Contain("Token"));
        Assert.That(ex.Message, Does.Contain("ClientId"));
    }

    [Test]
    public void Constructor_WithClientIdOnly_ShouldThrowArgumentException()
    {
        var ex = Assert.Throws<ArgumentException>(() => new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com",
            ClientId = "test-client-id"
        }));

        Assert.That(ex!.Message, Does.Contain("ClientSecret"));
    }

    [Test]
    public void Constructor_WithClientSecretOnly_ShouldThrowArgumentException()
    {
        var ex = Assert.Throws<ArgumentException>(() => new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com",
            ClientSecret = "test-client-secret"
        }));

        Assert.That(ex!.Message, Does.Contain("ClientId"));
    }

    [Test]
    public void Constructor_WithAllOptions_ShouldSucceed()
    {
        using var httpClient = new HttpClient();

        var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com",
            Token = "test-token",
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
    public void AllSubClients_ShouldBeAccessible()
    {
        var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com",
            Token = "test-token"
        });

        // Verify all sub-clients are accessible (not null)
        Assert.Multiple(() =>
        {
            Assert.That(client.Actions, Is.Not.Null);
            Assert.That(client.Branding, Is.Not.Null);
            Assert.That(client.ClientGrants, Is.Not.Null);
            Assert.That(client.Clients, Is.Not.Null);
            Assert.That(client.Connections, Is.Not.Null);
            Assert.That(client.CustomDomains, Is.Not.Null);
            Assert.That(client.DeviceCredentials, Is.Not.Null);
            Assert.That(client.EmailTemplates, Is.Not.Null);
            Assert.That(client.EventStreams, Is.Not.Null);
            Assert.That(client.Flows, Is.Not.Null);
            Assert.That(client.Forms, Is.Not.Null);
            Assert.That(client.UserGrants, Is.Not.Null);
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
            Assert.That(client.UserBlocks, Is.Not.Null);
            Assert.That(client.Users, Is.Not.Null);
            Assert.That(client.Anomaly, Is.Not.Null);
            Assert.That(client.AttackProtection, Is.Not.Null);
            Assert.That(client.Emails, Is.Not.Null);
            Assert.That(client.Guardian, Is.Not.Null);
            Assert.That(client.Keys, Is.Not.Null);
            Assert.That(client.Tenants, Is.Not.Null);
            Assert.That(client.VerifiableCredentials, Is.Not.Null);
        });
    }
}
