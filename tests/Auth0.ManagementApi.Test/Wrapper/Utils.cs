namespace Auth0.ManagementApi.Test.Utils;

/// <summary>
/// A <see cref="DelegatingHandler"/> that rewrites the host and port of every outgoing request
/// to a WireMock server URL. This allows tests to intercept HTTPS endpoints without requiring
/// a real TLS certificate.
/// </summary>
internal sealed class WireMockRedirectingHandler : DelegatingHandler
{
    private readonly Uri _targetBase;

    public WireMockRedirectingHandler(string wireMockUrl)
        : base(new HttpClientHandler())
    {
        _targetBase = new Uri(wireMockUrl);
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var original = request.RequestUri!;
        var redirected = new UriBuilder(original)
        {
            Scheme = _targetBase.Scheme,
            Host   = _targetBase.Host,
            Port   = _targetBase.Port,
        }.Uri;
        request.RequestUri = redirected;
        return base.SendAsync(request, cancellationToken);
    }
}