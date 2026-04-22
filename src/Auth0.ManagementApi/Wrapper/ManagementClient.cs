using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Auth0 Management API client with automatic token management.
///
/// Token handling is provided by an <see cref="ITokenProvider"/>:
/// <list type="bullet">
///   <item><see cref="DelegateTokenProvider"/> — retrieve tokens from a custom async source.</item>
///   <item><see cref="ClientCredentialsTokenProvider"/> — automatic token acquisition and refresh via OAuth 2.0 client credentials.</item>
/// </list>
///
/// Example (client credentials):
/// <code>
/// var client = new ManagementClient(new ManagementClientOptions
/// {
///     Domain = "tenant.auth0.com",
///     TokenProvider = new ClientCredentialsTokenProvider("tenant.auth0.com", "client_id", "client_secret")
/// });
/// </code>
/// </summary>
public sealed class ManagementClient : ManagementApiClient, IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly bool _ownsHttpClient;
    private readonly ITokenProvider _tokenProvider;

    /// <summary>
    /// Creates a new <see cref="ManagementClient"/> instance.
    /// </summary>
    /// <param name="options">Configuration options for the client.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="options"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <see cref="ManagementClientOptions.Domain"/> is empty, whitespace, or contains a scheme prefix.</exception>
    public ManagementClient(ManagementClientOptions options)
        : this(Validate(options), BuildClientOptions(options))
    {
    }

    private ManagementClient(ManagementClientOptions options, ClientOptions clientOptions)
        : base(null, clientOptions)
    {
        _tokenProvider = options.TokenProvider;
        _ownsHttpClient = options.HttpClient == null;
        _httpClient = clientOptions.HttpClient;

        // Replace the static "Bearer " auth header with a dynamic per-request supplier.
        SetAuthorizationHeader(async () =>
            $"Bearer {await _tokenProvider.GetTokenAsync(default).ConfigureAwait(false)}");
    }

    private static ManagementClientOptions Validate(ManagementClientOptions options)
    {
        if (options == null) throw new ArgumentNullException(nameof(options));

        if (string.IsNullOrWhiteSpace(options.Domain))
            throw new ArgumentException(
                "Domain must not be empty or whitespace.", nameof(options));
        if (options.Domain.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
            options.Domain.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException(
                "Domain must not include a scheme prefix (e.g. use 'tenant.auth0.com', not 'https://tenant.auth0.com').",
                nameof(options));
        if (options.TokenProvider == null)
            throw new ArgumentNullException(nameof(options), "TokenProvider must not be null.");

        return options;
    }

    private static HttpClient CreateHttpClient(ManagementClientOptions options) =>
        options.CustomDomain != null
            ? new HttpClient(new CustomDomainInterceptor())
            : new HttpClient();

    private static ClientOptions BuildClientOptions(ManagementClientOptions options)
    {
        // When a custom domain is configured and no HttpClient is supplied, automatically
        // inject CustomDomainInterceptor so the header is stripped from non-whitelisted paths.
        var httpClient = options.HttpClient ?? CreateHttpClient(options);

        var clientOptions = new ClientOptions
        {
            BaseUrl = $"https://{options.Domain}/api/v2",
            HttpClient = httpClient,
            Timeout = options.Timeout ?? TimeSpan.FromSeconds(30),
            MaxRetries = options.MaxRetries ?? 2,
        };

        if (options.AdditionalHeaders != null)
        {
            foreach (var header in options.AdditionalHeaders)
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }

        if (!string.IsNullOrEmpty(options.CustomDomain))
            clientOptions.Headers[CustomDomainInterceptor.HeaderName] = options.CustomDomain;

        return clientOptions;
    }

    /// <summary>
    /// Disposes the <see cref="ManagementClient"/> and releases managed resources.
    /// Only disposes the internal <see cref="HttpClient"/> if it was created by this instance.
    /// The <see cref="ITokenProvider"/> is not disposed — the caller owns it and is responsible for its lifetime.
    /// </summary>
    public void Dispose()
    {
        if (_ownsHttpClient)
        {
            _httpClient.Dispose();
        }
    }
}
