using System.Text.RegularExpressions;

namespace Auth0.ManagementApi.Core;

/// <summary>
/// A <see cref="DelegatingHandler"/> that enforces the <c>Auth0-Custom-Domain</c> header whitelist.
///
/// <para>
/// The <c>Auth0-Custom-Domain</c> header is only meaningful for specific Management API endpoints
/// that generate user-facing links (email verification, password reset, invitations, etc.).
/// This handler strips the header from requests to any path not on the whitelist, preventing
/// it from leaking to unrelated endpoints.
/// </para>
///
/// <para>Whitelisted paths:</para>
/// <list type="bullet">
///   <item><c>POST /tickets/email-verification</c></item>
///   <item><c>POST /tickets/password-change</c></item>
///   <item><c>POST /organizations/{id}/invitations</c></item>
///   <item><c>POST /guardian/enrollments/ticket</c></item>
///   <item><c>POST /jobs/verification-email</c></item>
///   <item><c>POST /jobs/users-imports</c></item>
///   <item><c>POST /users</c> and <c>PATCH /users/{id}</c></item>
///   <item><c>POST /self-service-profiles/{id}/sso-ticket</c></item>
/// </list>
/// </summary>
public class CustomDomainInterceptor : DelegatingHandler
{
    /// <summary>
    /// The name of the custom domain header.
    /// </summary>
    public const string HeaderName = "Auth0-Custom-Domain";

    private static readonly Regex[] WhitelistedPaths =
    {
        new Regex(@".*/tickets/email-verification$", RegexOptions.Compiled),
        new Regex(@".*/tickets/password-change$", RegexOptions.Compiled),
        new Regex(@".*/organizations/[^/]+/invitations(/[^/]+)?$", RegexOptions.Compiled),
        new Regex(@".*/guardian/enrollments/ticket$", RegexOptions.Compiled),
        new Regex(@".*/jobs/verification-email$", RegexOptions.Compiled),
        new Regex(@".*/jobs/users-imports$", RegexOptions.Compiled),
        new Regex(@".*/users(/[^/]+)?$", RegexOptions.Compiled),
        new Regex(@".*/self-service-profiles/[^/]+/sso-ticket(/[^/]+/revoke)?$", RegexOptions.Compiled),
    };

    /// <summary>
    /// Initializes a new instance of <see cref="CustomDomainInterceptor"/> with a default
    /// <see cref="HttpClientHandler"/> as the inner handler.
    /// </summary>
    public CustomDomainInterceptor()
        : base(new HttpClientHandler()) { }

    /// <summary>
    /// Initializes a new instance of <see cref="CustomDomainInterceptor"/> wrapping the
    /// specified inner handler.
    /// </summary>
    /// <param name="innerHandler">The inner <see cref="HttpMessageHandler"/> to delegate to.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="innerHandler"/> is null.</exception>
    public CustomDomainInterceptor(HttpMessageHandler innerHandler)
        : base(innerHandler ?? throw new ArgumentNullException(nameof(innerHandler))) { }

    /// <inheritdoc />
    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (request.Headers.Contains(HeaderName) &&
            !IsWhitelisted(request.RequestUri?.AbsolutePath))
        {
            request.Headers.Remove(HeaderName);
        }

        return base.SendAsync(request, cancellationToken);
    }

    /// <summary>
    /// Returns <c>true</c> if <paramref name="path"/> matches one of the whitelisted endpoint patterns.
    /// Used internally by <see cref="SendAsync"/> and exposed for unit testing via <c>InternalsVisibleTo</c>.
    /// </summary>
    /// <param name="path">The URL absolute path to test (e.g. <c>/api/v2/tickets/email-verification</c>).</param>
    internal static bool IsWhitelisted(string? path)
    {
        if (string.IsNullOrEmpty(path))
            return false;

        return WhitelistedPaths.Any(p => p.IsMatch(path));
    }
}
