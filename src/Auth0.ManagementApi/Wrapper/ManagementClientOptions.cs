namespace Auth0.ManagementApi;

/// <summary>
/// Configuration options for the ManagementClient.
/// </summary>
public class ManagementClientOptions
{
    /// <summary>
    /// Your Auth0 domain (e.g., "your-tenant.auth0.com").
    /// </summary>
    public required string Domain { get; init; }

    /// <summary>
    /// A static access token for authentication.
    /// Either Token/TokenProvider or ClientId+ClientSecret must be provided.
    /// </summary>
    public string? Token { get; init; }

    /// <summary>
    /// A function that returns an access token.
    /// Useful for dynamic token retrieval from external sources.
    /// Either Token/TokenProvider or ClientId+ClientSecret must be provided.
    /// </summary>
    public Func<string>? TokenProvider { get; init; }

    /// <summary>
    /// Your Auth0 application client ID.
    /// Required along with ClientSecret for automatic token acquisition.
    /// </summary>
    public string? ClientId { get; init; }

    /// <summary>
    /// Your Auth0 application client secret.
    /// Required along with ClientId for automatic token acquisition.
    /// </summary>
    public string? ClientSecret { get; init; }

    /// <summary>
    /// The API audience. Defaults to https://{Domain}/api/v2/
    /// </summary>
    public string? Audience { get; init; }

    /// <summary>
    /// Custom HttpClient for making requests.
    /// If not provided, a new HttpClient will be created.
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
    /// Additional headers to send with requests.
    /// </summary>
    public IDictionary<string, string>? AdditionalHeaders { get; init; }
}
