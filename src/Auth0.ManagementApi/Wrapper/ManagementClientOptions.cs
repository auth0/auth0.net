namespace Auth0.ManagementApi;

/// <summary>
/// Configuration options for <see cref="ManagementClient"/>.
/// </summary>
public class ManagementClientOptions
{
    /// <summary>
    /// Your Auth0 domain (e.g., "your-tenant.auth0.com").
    /// </summary>
    public required string Domain { get; init; }

    /// <summary>
    /// The token provider responsible for supplying access tokens to the Management API.
    ///
    /// Built-in options:
    /// <list type="bullet">
    ///   <item><see cref="DelegateTokenProvider"/> — for retrieving tokens from an external source (e.g., a secret manager).</item>
    ///   <item><see cref="ClientCredentialsTokenProvider"/> — for automatic token acquisition and refresh via client credentials.</item>
    /// </list>
    ///
    /// Implement <see cref="ITokenProvider"/> to supply tokens from any custom source.
    /// </summary>
    public required ITokenProvider TokenProvider { get; init; }

    /// <summary>
    /// Custom <see cref="System.Net.Http.HttpClient"/> for making Management API requests.
    /// If not provided, a new instance will be created and managed internally.
    /// </summary>
    public HttpClient? HttpClient { get; init; }

    /// <summary>
    /// Request timeout. Defaults to 30 seconds.
    /// </summary>
    public TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Maximum number of retry attempts for failed requests. Defaults to 2.
    /// </summary>
    public int? MaxRetries { get; init; }

    /// <summary>
    /// Additional headers to include with every request.
    /// </summary>
    public IDictionary<string, string>? AdditionalHeaders { get; init; }
}
