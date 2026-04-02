using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using NUnit.Framework;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;
using WireMock.Types;

namespace Auth0.ManagementApi.Test.Wrapper;

/// <summary>
/// Verifies that the Auth0-Client telemetry header is sent on every request,
/// regardless of which public entry point is used to construct the client.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Auth0ClientHeaderTests
{
    // Shared helpers

    private static WireMockServer StartServer() =>
        WireMockServer.Start(new WireMockServerSettings { StartAdminInterface = false });

    private static void StubCheckStatus(WireMockServer server) =>
        server
            .Given(Request.Create().WithPath("/api/v2/connections/test-id/status").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200));

    private static void StubCheckStatusPlain(WireMockServer server) =>
        server
            .Given(Request.Create().WithPath("/connections/test-id/status").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200));

    private static Auth0ClientHeaderData? DecodeHeader(string base64Url)
    {
        var padded = base64Url.Replace('-', '+').Replace('_', '/');
        padded += (padded.Length % 4) switch { 2 => "==", 3 => "=", _ => "" };
        var json = Encoding.UTF8.GetString(Convert.FromBase64String(padded));
        return JsonSerializer.Deserialize<Auth0ClientHeaderData>(json);
    }

    private static void AssertAuth0ClientHeader(IDictionary<string, WireMockList<string>> headers)
    {
        Assert.That(headers, Does.ContainKey("Auth0-Client"), "Auth0-Client header must be present");

        var raw = headers["Auth0-Client"].First();
        var data = DecodeHeader(raw);

        Assert.That(data, Is.Not.Null);
        Assert.That(data!.Name, Is.EqualTo("Auth0.Net"));
        Assert.That(data.Version, Is.Not.Null.And.Not.Empty);
        Assert.That(data.Env?.Target, Is.Not.Null.And.Not.Empty);
    }

    // --- ManagementApiClient (direct usage, no token wrapper) ---

    [Test]
    public async Task ManagementApiClient_Direct_SendsAuth0ClientHeader()
    {
        using var server = StartServer();
        StubCheckStatusPlain(server);

        var client = new ManagementApiClient(
            "test-token",
            new ClientOptions { BaseUrl = server.Urls[0], MaxRetries = 0 }
        );

        await client.Connections.CheckStatusAsync("test-id");

        var request = server.LogEntries.Single().RequestMessage;
        AssertAuth0ClientHeader(request.Headers!);
    }

    // --- ManagementClient (wrapper path) ---

    [Test]
    public async Task ManagementClient_SendsAuth0ClientHeader()
    {
        using var server = StartServer();
        StubCheckStatus(server);

        using var httpClient = new HttpClient(new WireMockRedirectingHandler(server.Urls[0]));
        using var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = "tenant.auth0.com",
            TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("test-token")),
            HttpClient = httpClient,
            MaxRetries = 0,
        });

        await client.Connections.CheckStatusAsync("test-id");

        var request = server.LogEntries.Single().RequestMessage;
        AssertAuth0ClientHeader(request.Headers!);
    }

    // --- Header value correctness ---

    [Test]
    public async Task Auth0ClientHeader_IsValidBase64Url()
    {
        using var server = StartServer();
        StubCheckStatusPlain(server);

        var client = new ManagementApiClient(
            "test-token",
            new ClientOptions { BaseUrl = server.Urls[0], MaxRetries = 0 }
        );
        await client.Connections.CheckStatusAsync("test-id");

        var raw = server.LogEntries.Single().RequestMessage.Headers!["Auth0-Client"].First();
        // Must not contain standard Base64 padding or non-URL-safe characters.
        Assert.That(raw, Does.Not.Contain("+"));
        Assert.That(raw, Does.Not.Contain("/"));
        Assert.That(raw, Does.Not.Contain("="));
    }

    [Test]
    public async Task Auth0ClientHeader_ContainsExpectedFields()
    {
        using var server = StartServer();
        StubCheckStatusPlain(server);

        var client = new ManagementApiClient(
            "test-token",
            new ClientOptions { BaseUrl = server.Urls[0], MaxRetries = 0 }
        );
        await client.Connections.CheckStatusAsync("test-id");

        var raw = server.LogEntries.Single().RequestMessage.Headers!["Auth0-Client"].First();
        var data = DecodeHeader(raw);

        Assert.That(data, Is.Not.Null);
        Assert.That(data!.Name, Is.EqualTo("Auth0.Net"));
        Assert.That(data.Version, Is.Not.Null.And.Not.Empty);
        Assert.That(data.Env, Is.Not.Null);
        Assert.That(data.Env!.Target, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public async Task Auth0ClientHeader_IsPresentOnEveryNewInstance()
    {
        // Each client instance backed by its own ClientOptions must independently
        // include the header — it must not be a shared/static value that could be
        // accidentally cleared or overwritten.
        using var server = StartServer();
        StubCheckStatusPlain(server);

        var client1 = new ManagementApiClient(
            "token-1",
            new ClientOptions { BaseUrl = server.Urls[0], MaxRetries = 0 }
        );
        var client2 = new ManagementApiClient(
            "token-2",
            new ClientOptions { BaseUrl = server.Urls[0], MaxRetries = 0 }
        );

        await client1.Connections.CheckStatusAsync("test-id");
        await client2.Connections.CheckStatusAsync("test-id");

        Assert.That(server.LogEntries, Has.Count.EqualTo(2));
        foreach (var entry in server.LogEntries)
        {
            Assert.That(entry.RequestMessage.Headers, Does.ContainKey("Auth0-Client"));
        }
    }

    private record Auth0ClientHeaderData(
        [property: JsonPropertyName("name")] string? Name,
        [property: JsonPropertyName("version")] string? Version,
        [property: JsonPropertyName("env")] Auth0ClientEnv? Env
    );

    private record Auth0ClientEnv(
        [property: JsonPropertyName("target")] string? Target
    );
}
