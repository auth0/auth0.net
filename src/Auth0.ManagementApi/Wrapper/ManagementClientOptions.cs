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

    /// <summary>
    /// Custom domain to include as the <c>Auth0-Custom-Domain</c> header on Management API
    /// endpoints that generate user-facing links (email verification, password reset,
    /// invitations, MFA enrollment tickets, etc.).
    ///
    /// <para>
    /// When set and no <see cref="HttpClient"/> is provided, a <see cref="Core.CustomDomainInterceptor"/>
    /// is automatically configured to strip the header from non-applicable endpoints.
    /// When a custom <see cref="HttpClient"/> is supplied, the header is still included on
    /// every request but stripping is the caller's responsibility.
    /// </para>
    /// </summary>
    public string? CustomDomain { get; init; }
}
