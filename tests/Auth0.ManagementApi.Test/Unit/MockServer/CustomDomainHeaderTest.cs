using Auth0.ManagementApi.Core;
using NUnit.Framework;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;
using WireMock.Logging;

namespace Auth0.ManagementApi.Test.Unit.MockServer;

/// <summary>
/// End-to-end tests for the Auth0-Custom-Domain header feature using WireMock as the HTTP backend.
/// </summary>
[TestFixture]
public class CustomDomainHeaderTest
{
    private WireMockServer _server = null!;

    [OneTimeSetUp]
    public void GlobalSetup()
    {
        _server = WireMockServer.Start(
            new WireMockServerSettings { Logger = new WireMockConsoleLogger() });
    }

    [OneTimeTearDown]
    public void GlobalTeardown()
    {
        _server.Stop();
        _server.Dispose();
    }

    [SetUp]
    public void Setup() => _server.Reset();

    private ManagementApiClient BuildClient(string? customDomain = null, bool withInterceptor = false)
    {
        var httpClient = withInterceptor
            ? new HttpClient(new CustomDomainInterceptor(new HttpClientHandler()))
            : new HttpClient();

        return new ManagementApiClient(
            "TOKEN",
            new ClientOptions
            {
                BaseUrl = _server.Urls[0],
                MaxRetries = 0,
                CustomDomain = customDomain,
                HttpClient = httpClient,
            });
    }

    private void StubAny(string path, string method = "GET") =>
        _server
            .Given(Request.Create().WithPath(path).UsingMethod(method))
            .RespondWith(Response.Create().WithStatusCode(200).WithBody("{}"));

    private bool HasCustomDomainHeader(string domain) =>
        _server.LogEntries.Any(e =>
            e.RequestMessage.Headers.ContainsKey(CustomDomainInterceptor.HeaderName) &&
            e.RequestMessage.Headers[CustomDomainInterceptor.HeaderName]
                .Contains(domain, StringComparer.OrdinalIgnoreCase));

    private bool HasNoCustomDomainHeader() =>
        _server.LogEntries.All(e =>
            !e.RequestMessage.Headers.ContainsKey(CustomDomainInterceptor.HeaderName));

    [Test]
    public async Task GlobalConfig_WhitelistedEndpoint_HeaderPresent()
    {
        StubAny("/tickets/email-verification", "POST");
        var client = BuildClient(customDomain: "login.mycompany.com");

        try
        {
            await client.Tickets.VerifyEmailAsync(
                new VerifyEmailTicketRequestContent { UserId = "auth0|123" });
        }
        catch { /* ignore deserialization of empty body */ }

        Assert.That(_server.LogEntries, Has.Count.GreaterThan(0));
        Assert.That(HasCustomDomainHeader("login.mycompany.com"), Is.True);
    }

    [Test]
    public async Task GlobalConfig_NoInterceptor_NonWhitelistedEndpoint_HeaderStillSent()
    {
        // Without the interceptor, the header is present on ALL requests (including non-whitelisted).
        // Servers ignore unknown headers, so this is acceptable. Document the behaviour here.
        StubAny("/connections/conn_1/status");
        var client = BuildClient(customDomain: "login.mycompany.com");

        await client.Connections.CheckStatusAsync("conn_1");

        Assert.That(_server.LogEntries, Has.Count.GreaterThan(0));
        Assert.That(HasCustomDomainHeader("login.mycompany.com"), Is.True,
            "Without CustomDomainInterceptor the header is present on all requests.");
    }

    [Test]
    public async Task GlobalConfig_WithInterceptor_WhitelistedEndpoint_HeaderPresent()
    {
        StubAny("/tickets/email-verification", "POST");
        var client = BuildClient(customDomain: "login.mycompany.com", withInterceptor: true);

        try
        {
            await client.Tickets.VerifyEmailAsync(
                new VerifyEmailTicketRequestContent { UserId = "auth0|123" });
        }
        catch { /* ignore deserialization of empty body */ }

        Assert.That(_server.LogEntries, Has.Count.GreaterThan(0));
        Assert.That(HasCustomDomainHeader("login.mycompany.com"), Is.True);
    }

    [Test]
    public async Task GlobalConfig_WithInterceptor_NonWhitelistedEndpoint_HeaderStripped()
    {
        StubAny("/connections/conn_1/status");
        var client = BuildClient(customDomain: "login.mycompany.com", withInterceptor: true);

        await client.Connections.CheckStatusAsync("conn_1");

        Assert.That(_server.LogEntries, Has.Count.GreaterThan(0));
        Assert.That(HasNoCustomDomainHeader(), Is.True,
            "CustomDomainInterceptor should strip the header from non-whitelisted paths.");
    }

    [Test]
    public async Task PerRequest_WhitelistedEndpoint_HeaderPresent()
    {
        StubAny("/tickets/email-verification", "POST");
        var client = BuildClient(); // no global custom domain

        try
        {
            await client.Tickets.VerifyEmailAsync(
                new VerifyEmailTicketRequestContent { UserId = "auth0|123" },
                CustomDomainHeader.For("login.mycompany.com"));
        }
        catch { /* ignore deserialization of empty body */ }

        Assert.That(_server.LogEntries, Has.Count.GreaterThan(0));
        Assert.That(HasCustomDomainHeader("login.mycompany.com"), Is.True);
    }

    [Test]
    public async Task PerRequest_OverridesGlobalDomain()
    {
        StubAny("/tickets/email-verification", "POST");
        var client = BuildClient(customDomain: "global.mycompany.com");

        try
        {
            await client.Tickets.VerifyEmailAsync(
                new VerifyEmailTicketRequestContent { UserId = "auth0|123" },
                CustomDomainHeader.For("override.mycompany.com"));
        }
        catch { /* ignore deserialization of empty body */ }

        Assert.That(_server.LogEntries, Has.Count.GreaterThan(0));
        // The per-request value should appear (AdditionalHeaders override Options.Headers)
        Assert.That(HasCustomDomainHeader("override.mycompany.com"), Is.True);
    }

    [Test]
    public async Task NoCustomDomain_HeaderAbsent()
    {
        StubAny("/connections/conn_1/status");
        var client = BuildClient(); // no custom domain

        await client.Connections.CheckStatusAsync("conn_1");

        Assert.That(_server.LogEntries, Has.Count.GreaterThan(0));
        Assert.That(HasNoCustomDomainHeader(), Is.True);
    }

    [Test]
    public async Task PerRequest_WithOtherAdditionalHeaders_AllHeadersPresent()
    {
        // Users who need custom domain AND other per-request headers construct RequestOptions
        // directly rather than using CustomDomainHeader.For(), which only sets the custom domain.
        StubAny("/tickets/email-verification", "POST");
        var client = BuildClient();

        try
        {
            await client.Tickets.VerifyEmailAsync(
                new VerifyEmailTicketRequestContent { UserId = "auth0|123" },
                new RequestOptions
                {
                    AdditionalHeaders = new[]
                    {
                        new KeyValuePair<string, string?>(
                            CustomDomainInterceptor.HeaderName, "login.mycompany.com"),
                        new KeyValuePair<string, string?>(
                            "X-Correlation-Id", "test-correlation-id"),
                    },
                });
        }
        catch { /* ignore deserialization of empty body */ }

        Assert.That(_server.LogEntries, Has.Count.GreaterThan(0));

        var headers = _server.LogEntries[0].RequestMessage.Headers;

        Assert.That(HasCustomDomainHeader("login.mycompany.com"), Is.True,
            "Auth0-Custom-Domain header should be present");
        Assert.That(headers.ContainsKey("X-Correlation-Id"), Is.True,
            "X-Correlation-Id should be present alongside Auth0-Custom-Domain");
        Assert.That(headers["X-Correlation-Id"].First(), Is.EqualTo("test-correlation-id"));
    }

    [Test]
    public async Task GlobalConfig_WithInterceptor_NonWhitelistedEndpoint_OtherHeadersPreserved()
    {
        // The interceptor must only strip Auth0-Custom-Domain; it must not affect other
        // custom headers the caller has added to the request.
        _server
            .Given(Request.Create().WithPath("/connections/conn_1/status").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200).WithBody("{}"));

        var httpClient = new HttpClient(new CustomDomainInterceptor(new HttpClientHandler()));
        var client = new ManagementApiClient(
            "TOKEN",
            new ClientOptions
            {
                BaseUrl = _server.Urls[0],
                MaxRetries = 0,
                CustomDomain = "login.mycompany.com",
                HttpClient = httpClient,
                AdditionalHeaders = new[]
                {
                    new KeyValuePair<string, string?>("X-Custom-Global", "global-value"),
                },
            });

        await client.Connections.CheckStatusAsync("conn_1");

        Assert.That(_server.LogEntries, Has.Count.GreaterThan(0));

        var headers = _server.LogEntries[0].RequestMessage.Headers;

        Assert.That(headers.ContainsKey(CustomDomainInterceptor.HeaderName), Is.False,
            "Auth0-Custom-Domain should be stripped from non-whitelisted endpoint");
        Assert.That(headers.ContainsKey("X-Custom-Global"), Is.True,
            "Other custom headers must not be removed by the interceptor");
        Assert.That(headers["X-Custom-Global"].First(), Is.EqualTo("global-value"));
    }
}
