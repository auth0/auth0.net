using System.Text;
using System.Text.Json;

namespace Auth0.ManagementApi;

/// <summary>
/// Token provider with caching and automatic refresh.
/// Fetches tokens via OAuth 2.0 client credentials grant and caches them
/// until they expire (with a 10-second leeway for safety).
/// Thread-safe: uses a lock to prevent concurrent token fetches.
/// </summary>
internal sealed class TokenProvider
{
    private readonly string _domain;
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly string _audience;
    private readonly HttpClient _httpClient;
    private readonly bool _ownsHttpClient;

    private string? _accessToken;
    private DateTime _expiresAt = DateTime.MinValue;
    private readonly object _lock = new();

    private const int LeewaySeconds = 10;

    /// <summary>
    /// Creates a new TokenProvider for client credentials authentication.
    /// </summary>
    /// <param name="domain">The Auth0 domain.</param>
    /// <param name="clientId">The client ID.</param>
    /// <param name="clientSecret">The client secret.</param>
    /// <param name="audience">The API audience. If null, defaults to https://{domain}/api/v2/</param>
    /// <param name="httpClient">Optional HttpClient. If null, a new one will be created.</param>
    public TokenProvider(
        string domain,
        string clientId,
        string clientSecret,
        string? audience = null,
        HttpClient? httpClient = null)
    {
        _domain = domain ?? throw new ArgumentNullException(nameof(domain));
        _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
        _clientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));
        _audience = audience ?? $"https://{domain}/api/v2/";
        _httpClient = httpClient ?? new HttpClient();
        _ownsHttpClient = httpClient == null;
    }

    /// <summary>
    /// Gets a valid access token, fetching a new one if expired.
    /// Thread-safe with double-check locking pattern.
    /// </summary>
    /// <returns>A valid access token.</returns>
    public string GetToken()
    {
        // Fast path: return cached token if still valid
        if (_accessToken != null && DateTime.UtcNow < _expiresAt.AddSeconds(-LeewaySeconds))
        {
            return _accessToken;
        }

        lock (_lock)
        {
            // Double-check after acquiring lock
            if (_accessToken != null && DateTime.UtcNow < _expiresAt.AddSeconds(-LeewaySeconds))
            {
                return _accessToken;
            }

            FetchToken();
        }

        return _accessToken!;
    }

    /// <summary>
    /// Fetches a new token via client credentials grant.
    /// Must be called while holding the lock.
    /// </summary>
    private void FetchToken()
    {
        var url = $"https://{_domain}/oauth/token";
        var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["grant_type"] = "client_credentials",
            ["client_id"] = _clientId,
            ["client_secret"] = _clientSecret,
            ["audience"] = _audience
        });

        using var response = _httpClient.PostAsync(url, content).GetAwaiter().GetResult();
        response.EnsureSuccessStatusCode();

        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        using var document = JsonDocument.Parse(json);
        var root = document.RootElement;

        _accessToken = root.GetProperty("access_token").GetString()
            ?? throw new InvalidOperationException("Token response missing access_token");

        var expiresIn = root.GetProperty("expires_in").GetInt32();
        _expiresAt = DateTime.UtcNow.AddSeconds(expiresIn);
    }
}
