namespace Auth0.AuthenticationApi.Models;

/// <summary>
/// Well-known OAuth 2.0 Token Exchange (RFC 8693) token type URNs, plus the
/// Auth0-specific Session Transfer Token type.
/// </summary>
/// <remarks>
/// These are provided for convenience and discoverability. The token-type
/// properties on <see cref="TokenExchangeTokenRequest"/> are plain strings, so a
/// caller may also supply a custom or future URN not listed here.
/// </remarks>
public static class TokenType
{
    /// <summary>
    /// Indicates that the token is an OIDC ID Token: <c>urn:ietf:params:oauth:token-type:id_token</c>.
    /// </summary>
    public const string IdToken = "urn:ietf:params:oauth:token-type:id_token";

    /// <summary>
    /// Indicates that the token is an OAuth 2.0 access token: <c>urn:ietf:params:oauth:token-type:access_token</c>.
    /// </summary>
    public const string AccessToken = "urn:ietf:params:oauth:token-type:access_token";

    /// <summary>
    /// Indicates that the token is a JWT: <c>urn:ietf:params:oauth:token-type:jwt</c>.
    /// </summary>
    public const string Jwt = "urn:ietf:params:oauth:token-type:jwt";

    /// <summary>
    /// Indicates that the token is an Auth0 Session Transfer Token: <c>urn:auth0:params:oauth:token-type:session_transfer_token</c>.
    /// </summary>
    public const string SessionTransferToken = "urn:auth0:params:oauth:token-type:session_transfer_token";
}
