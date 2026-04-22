using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Convenience helper for creating per-request <c>Auth0-Custom-Domain</c> overrides.
///
/// <para>
/// Use this when you need to specify a custom domain for a single API call without
/// configuring it globally on the client. The header is forwarded only to whitelisted
/// endpoints — if you have a <see cref="CustomDomainInterceptor"/> configured on your
/// <see cref="System.Net.Http.HttpClient"/>, it is stripped automatically from any
/// non-whitelisted path.
/// </para>
///
/// <para>
/// When you need the custom domain header <em>and</em> other <see cref="RequestOptions"/>
/// settings (extra headers, timeout, retries) in the same call, construct
/// <see cref="RequestOptions"/> directly instead of using this helper:
/// <code>
/// await client.Tickets.VerifyEmailAsync(request, new RequestOptions
/// {
///     AdditionalHeaders = new[]
///     {
///         new KeyValuePair&lt;string, string?&gt;(CustomDomainInterceptor.HeaderName, "login.mycompany.com"),
///         new KeyValuePair&lt;string, string?&gt;("X-Correlation-Id", "abc-123"),
///     },
///     MaxRetries = 1,
/// });
/// </code>
/// </para>
///
/// <example>
/// <code>
/// // Override for a specific request
/// await client.Tickets.VerifyEmailAsync(request, CustomDomainHeader.For("login.mycompany.com"));
///
/// // Override for organization invitations
/// await client.Organizations.Invitations.CreateAsync(orgId, invitation, CustomDomainHeader.For("login.mycompany.com"));
/// </code>
/// </example>
/// </summary>
public static class CustomDomainHeader
{
    /// <summary>
    /// Creates a <see cref="RequestOptions"/> with the <c>Auth0-Custom-Domain</c> header set
    /// to <paramref name="domain"/>.
    /// </summary>
    /// <param name="domain">The custom domain (e.g. <c>"login.mycompany.com"</c>).</param>
    /// <returns>A <see cref="RequestOptions"/> carrying the custom domain header.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="domain"/> is null, empty, or whitespace.</exception>
    public static RequestOptions For(string domain)
    {
        if (string.IsNullOrWhiteSpace(domain))
            throw new ArgumentException("Domain must not be null or whitespace.", nameof(domain));

        return new RequestOptions
        {
            AdditionalHeaders = new[]
            {
                new KeyValuePair<string, string?>(CustomDomainInterceptor.HeaderName, domain),
            },
        };
    }
}
