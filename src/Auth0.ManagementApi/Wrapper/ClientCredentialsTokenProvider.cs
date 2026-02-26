using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;

namespace Auth0.ManagementApi;

/// <summary>
/// An <see cref="ITokenProvider"/> that automatically acquires and caches tokens
/// via the OAuth 2.0 client credentials grant.
///
/// Tokens are cached until they expire (with a 10-second leeway for safety) and
/// refreshed transparently on the next call.
/// </summary>
public sealed class ClientCredentialsTokenProvider : ITokenProvider, IDisposable
{
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly string _audience;
    private readonly AuthenticationApiClient _authClient;
    private readonly SemaphoreSlim _semaphore = new(1, 1);

    private string? _accessToken;

    private long _expiresAtTicks = DateTime.MinValue.Ticks;

    private const int LeewaySeconds = 10;

    /// <summary>
    /// Creates a new <see cref="ClientCredentialsTokenProvider"/> for automatic token acquisition.
    /// </summary>
    /// <param name="domain">The Auth0 domain (e.g., "your-tenant.auth0.com").</param>
    /// <param name="clientId">The client ID of the application.</param>
    /// <param name="clientSecret">The client secret of the application.</param>
    /// <param name="audience">
    /// The API audience. Defaults to <c>https://{domain}/api/v2/</c>.
    /// </param>
    /// <param name="httpClient">
    /// An optional <see cref="HttpClient"/> for making token requests.
    /// If not provided, a new instance will be created and managed internally.
    /// </param>
    public ClientCredentialsTokenProvider(
        string domain,
        string clientId,
        string clientSecret,
        string? audience = null,
        HttpClient? httpClient = null)
    {
        if (string.IsNullOrWhiteSpace(domain))
            throw new ArgumentException("Domain must not be null, empty, or whitespace.", nameof(domain));
        if (string.IsNullOrWhiteSpace(clientId))
            throw new ArgumentException("Client ID must not be null, empty, or whitespace.", nameof(clientId));
        if (string.IsNullOrWhiteSpace(clientSecret))
            throw new ArgumentException("Client secret must not be null, empty, or whitespace.", nameof(clientSecret));

        _clientId = clientId;
        _clientSecret = clientSecret;
        _audience = audience ?? $"https://{domain}/api/v2/";

        var connection = httpClient != null
            ? new HttpClientAuthenticationConnection(httpClient)
            : null;
        _authClient = new AuthenticationApiClient(domain, connection);
    }

    /// <summary>
    /// Returns a valid access token, fetching a new one from Auth0 if the cached
    /// token has expired or does not yet exist. Thread-safe.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    public async Task<string> GetTokenAsync(CancellationToken cancellationToken = default)
    {
        var cachedToken = Volatile.Read(ref _accessToken);
        var expiresAt = new DateTime(Interlocked.Read(ref _expiresAtTicks), DateTimeKind.Utc);
        if (cachedToken != null && DateTime.UtcNow < expiresAt.AddSeconds(-LeewaySeconds))
        {
            return cachedToken;
        }

        await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            // Double-check after acquiring the semaphore
            cachedToken = Volatile.Read(ref _accessToken);
            expiresAt = new DateTime(Interlocked.Read(ref _expiresAtTicks), DateTimeKind.Utc);
            if (cachedToken != null && DateTime.UtcNow < expiresAt.AddSeconds(-LeewaySeconds))
            {
                return cachedToken;
            }

            await FetchTokenAsync(cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _semaphore.Release();
        }

        return Volatile.Read(ref _accessToken)!;
    }

    private async Task FetchTokenAsync(CancellationToken cancellationToken)
    {
        var response = await _authClient.GetTokenAsync(new ClientCredentialsTokenRequest
        {
            ClientId     = _clientId,
            ClientSecret = _clientSecret,
            Audience     = _audience
        }, cancellationToken).ConfigureAwait(false);

        var newExpiryTicks = DateTime.UtcNow.AddSeconds(response.ExpiresIn).Ticks;

        // Write expiry first, then the token. The fast-path reader checks the token
        // for null before examining the expiry, so this ordering ensures it never
        // reads a fresh token paired with a stale expiry.
        Interlocked.Exchange(ref _expiresAtTicks, newExpiryTicks);
        Volatile.Write(ref _accessToken, response.AccessToken);
    }

    /// <summary>
    /// Releases resources held by this provider.
    /// </summary>
    public void Dispose()
    {
        _semaphore.Dispose();
        _authClient.Dispose();
    }
}
