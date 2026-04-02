using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace Auth0.ManagementApi.Test.Wrapper.TokenProviders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DelegateTokenProviderTests
{
    private WireMockServer _server = null!;

    [SetUp]
    public void SetUp()
    {
        _server = WireMockServer.Start(new WireMockServerSettings());
        _server
            .Given(Request.Create().WithPath("/api/v2/connections/test-id/status").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200));
    }

    [TearDown]
    public void TearDown()
    {
        _server.Stop();
        _server.Dispose();
    }

    [Test]
    public async Task DelegateTokenProvider_TokenAppears_As_AuthorizationHeader()
    {
        var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = ExtractHost(_server.Urls[0]),
            TokenProvider = new DelegateTokenProvider(_ => Task.FromResult("delegate-bearer-token")),
            HttpClient = CreateHttpClientForServer(_server.Urls[0]),
            MaxRetries = 0
        });

        await client.Connections.CheckStatusAsync("test-id");

        var entry = _server.LogEntries.Single();
        var authHeader = entry.RequestMessage.Headers?["Authorization"]?.FirstOrDefault();
        Assert.That(authHeader, Is.EqualTo("Bearer delegate-bearer-token"));
    }

    [Test]
    public async Task GetTokenAsync_InvokesDelegate_EachCall()
    {
        var callCount = 0;
        var provider = new DelegateTokenProvider(async _ =>
        {
            callCount++;
            return await Task.FromResult($"token-{callCount}");
        });

        var first = await provider.GetTokenAsync();
        var second = await provider.GetTokenAsync();

        // No caching: delegate is called on every invocation
        Assert.That(callCount, Is.EqualTo(2));
        Assert.That(first, Is.EqualTo("token-1"));
        Assert.That(second, Is.EqualTo("token-2"));
    }

    [Test]
    public async Task GetTokenAsync_ForwardsCancellationToken_ToDelegate()
    {
        CancellationToken captured = default;
        using var cts = new CancellationTokenSource();

        var provider = new DelegateTokenProvider(ct =>
        {
            captured = ct;
            return Task.FromResult("token");
        });

        await provider.GetTokenAsync(cts.Token);

        Assert.That(captured, Is.EqualTo(cts.Token));
    }

    [Test]
    public void GetTokenAsync_WithCancelledToken_Throws()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        var provider = new DelegateTokenProvider(ct =>
        {
            ct.ThrowIfCancellationRequested();
            return Task.FromResult("token");
        });

        Assert.ThrowsAsync<OperationCanceledException>(() => provider.GetTokenAsync(cts.Token));
    }

    [Test]
    public void Constructor_NullFactory_Throws()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new DelegateTokenProvider((Func<CancellationToken, Task<string>>)null!));
    }

    [Test]
    public void GetTokenAsync_NullReturnFromDelegate_Throws()
    {
        var provider = new DelegateTokenProvider(_ => Task.FromResult<string>(null!));

        Assert.ThrowsAsync<InvalidOperationException>(() => provider.GetTokenAsync());
    }


    /// <summary>
    /// Extracts just the host portion of a URL so ManagementClient builds its base URL against it.
    /// ManagementClient prepends "https://{domain}/api/v2", so we override the scheme/port via HttpClient.
    /// </summary>
    private static string ExtractHost(string url) => new Uri(url).Host;

    private static HttpClient CreateHttpClientForServer(string serverUrl)
    {
        return new HttpClient(new WireMockRedirectingHandler(serverUrl));
    }
}
