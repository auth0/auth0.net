using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace Auth0.ManagementApi.Test.Wrapper.TokenProviders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ClientCredentialsTokenProviderTests
{
    private WireMockServer _server = null!;
    private string _domain = null!;

    [SetUp]
    public void SetUp()
    {
        _server = WireMockServer.Start(new WireMockServerSettings());
        // The domain is just the host:port portion; the provider builds the URL as https://{domain}/oauth/token,
        // but we point the HttpClient's base address at the mock server instead via a custom HttpClient handler.
        _domain = "tenant.auth0.com";
    }

    [TearDown]
    public void TearDown()
    {
        _server.Stop();
        _server.Dispose();
    }

    private ClientCredentialsTokenProvider CreateProvider(
        string? audience = null,
        HttpClient? httpClient = null)
    {
        // We need to intercept requests to https://tenant.auth0.com/oauth/token.
        // We redirect them to the WireMock server by providing an HttpClient whose
        // BaseAddress is overridden via a delegating handler.
        var redirectingClient = httpClient ?? CreateRedirectingHttpClient();
        return new ClientCredentialsTokenProvider(
            _domain, "test-client-id", "test-client-secret", audience, redirectingClient);
    }

    private HttpClient CreateRedirectingHttpClient()
    {
        return new HttpClient(new WireMockRedirectingHandler(_server.Urls[0]));
    }

    private void SetupTokenEndpoint(string accessToken, int expiresIn = 3600)
    {
        _server
            .Given(Request.Create().WithPath("/oauth/token").UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody($"{{\"access_token\":\"{accessToken}\",\"expires_in\":{expiresIn},\"token_type\":\"Bearer\"}}"));
    }

    [Test]
    public async Task GetTokenAsync_FetchesToken_OnFirstCall()
    {
        SetupTokenEndpoint("first-token");
        using var provider = CreateProvider();

        var token = await provider.GetTokenAsync();

        Assert.That(token, Is.EqualTo("first-token"));
        Assert.That(_server.LogEntries.Count(), Is.EqualTo(1));
    }

    [Test]
    public async Task GetTokenAsync_ReturnsCachedToken_BeforeExpiry()
    {
        SetupTokenEndpoint("cached-token", expiresIn: 3600);
        using var provider = CreateProvider();

        var first = await provider.GetTokenAsync();
        var second = await provider.GetTokenAsync();

        Assert.That(first, Is.EqualTo("cached-token"));
        Assert.That(second, Is.EqualTo("cached-token"));
        // Token endpoint should only have been hit once
        Assert.That(_server.LogEntries.Count(), Is.EqualTo(1));
    }

    [Test]
    public async Task GetTokenAsync_IsThreadSafe_UnderConcurrentCalls()
    {
        SetupTokenEndpoint("concurrent-token", expiresIn: 3600);
        using var provider = CreateProvider();

        var tasks = Enumerable.Range(0, 20).Select(_ => provider.GetTokenAsync());
        var results = await Task.WhenAll(tasks);

        // All results should be the same token
        Assert.That(results, Is.All.EqualTo("concurrent-token"));
        // Token endpoint should only have been hit once (caching prevents duplicate fetches)
        Assert.That(_server.LogEntries.Count(), Is.EqualTo(1));
    }

    [TestCase(null!)]
    [TestCase("")]
    [TestCase("   ")]
    public void Constructor_InvalidDomain_Throws(string? domain)
    {
        Assert.Throws<ArgumentException>(() =>
            new ClientCredentialsTokenProvider(domain!, "client-id", "client-secret"));
    }

    [TestCase(null!)]
    [TestCase("")]
    [TestCase("   ")]
    public void Constructor_InvalidClientId_Throws(string? clientId)
    {
        Assert.Throws<ArgumentException>(() =>
            new ClientCredentialsTokenProvider("domain", clientId!, "client-secret"));
    }

    [TestCase(null!)]
    [TestCase("")]
    [TestCase("   ")]
    public void Constructor_InvalidClientSecret_Throws(string? clientSecret)
    {
        Assert.Throws<ArgumentException>(() =>
            new ClientCredentialsTokenProvider("domain", "client-id", clientSecret!));
    }

    [Test]
    public async Task Constructor_NullAudience_DefaultsToApiV2Audience()
    {
        // We verify the default audience is sent in the token request body
        _server
            .Given(Request.Create().WithPath("/oauth/token").UsingPost()
                .WithBody(b => b != null && b.Contains("audience=https%3A%2F%2Ftenant.auth0.com%2Fapi%2Fv2%2F")))
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"access_token\":\"token\",\"expires_in\":3600,\"token_type\":\"Bearer\"}"));

        using var provider = CreateProvider(audience: null);

        var token = await provider.GetTokenAsync();

        Assert.That(token, Is.EqualTo("token"));
    }

    [Test]
    public async Task GetTokenAsync_ThrowsDescriptiveException_WhenTokenEndpointFails()
    {
        _server
            .Given(Request.Create().WithPath("/oauth/token").UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(401)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"error\":\"invalid_client\",\"error_description\":\"Unknown client.\"}"));

        using var provider = CreateProvider();

        var ex = Assert.ThrowsAsync<ErrorApiException>(() => provider.GetTokenAsync());
        Assert.That(ex!.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Unauthorized));
        Assert.That(ex.ApiError!.Error, Is.EqualTo("invalid_client"));
    }

    [Test]
    public async Task GetTokenAsync_RefreshesToken_AfterExpiry()
    {
        // expiresIn: 0 means _expiresAt = UtcNow + 0s.
        // The leeway check is: UtcNow < _expiresAt - 10s, which is immediately false,
        // so the token is stale on the very next call. No time-mocking needed.
        _server
            .Given(Request.Create().WithPath("/oauth/token").UsingPost())
            .InScenario("token-refresh")
            .WillSetStateTo("first-fetched")
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"access_token\":\"token-v1\",\"expires_in\":0,\"token_type\":\"Bearer\"}"));

        _server
            .Given(Request.Create().WithPath("/oauth/token").UsingPost())
            .InScenario("token-refresh")
            .WhenStateIs("first-fetched")
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"access_token\":\"token-v2\",\"expires_in\":3600,\"token_type\":\"Bearer\"}"));

        using var provider = CreateProvider();

        var first = await provider.GetTokenAsync();
        var second = await provider.GetTokenAsync();

        Assert.That(first, Is.EqualTo("token-v1"));
        Assert.That(second, Is.EqualTo("token-v2"));
        Assert.That(_server.LogEntries.Count(), Is.EqualTo(2));
    }

}
