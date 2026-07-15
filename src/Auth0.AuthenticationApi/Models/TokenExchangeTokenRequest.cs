using Microsoft.IdentityModel.Tokens;

namespace Auth0.AuthenticationApi.Models;

/// <summary>
/// Represents a request to exchange a token using the OAuth 2.0 Token Exchange grant
/// (RFC 8693), also known as Custom Token Exchange.
/// </summary>
/// <remarks>
/// The same request covers both a normal access-token exchange (Phase 1) and an Auth0
/// Session Transfer Token exchange (Phase 2) — the latter by setting
/// <see cref="Audience"/> to the session-transfer audience and supplying an actor token.
/// </remarks>
public class TokenExchangeTokenRequest : IClientAuthentication
{
    /// <summary>
    /// The token that represents the identity of the party on behalf of whom the request
    /// is being made. Required.
    /// </summary>
    public string SubjectToken { get; set; }

    /// <summary>
    /// An identifier that indicates the type of <see cref="SubjectToken"/>, as a URN.
    /// See <see cref="TokenType"/> for well-known values. Required.
    /// </summary>
    public string SubjectTokenType { get; set; }

    /// <summary>
    /// Optional token that represents the identity of the acting party. When supplied,
    /// <see cref="ActorTokenType"/> must also be supplied (both-or-neither).
    /// </summary>
    public string ActorToken { get; set; }

    /// <summary>
    /// An identifier that indicates the type of <see cref="ActorToken"/>, as a URN.
    /// Required if <see cref="ActorToken"/> is set; must be omitted otherwise.
    /// </summary>
    public string ActorTokenType { get; set; }

    /// <summary>
    /// Optional target audience (API identifier) for the requested token. For a Session
    /// Transfer Token, set this to the session-transfer audience.
    /// </summary>
    public string Audience { get; set; }

    /// <summary>
    /// Optional space-delimited scopes for the requested token.
    /// </summary>
    public string Scope { get; set; }

    /// <summary>
    /// Optional human-readable reason for the exchange, recorded for audit/logging.
    /// </summary>
    public string Reason { get; set; }

    /// <summary>
    /// Optional organization. Can be an Organization Name or ID.
    /// </summary>
    public string Organization { get; set; }

    /// <summary>
    /// Client ID of the application.
    /// </summary>
    public string ClientId { get; set; }

    /// <summary>
    /// Client Secret of the application.
    /// </summary>
    public string ClientSecret { get; set; }

    /// <summary>
    /// Security Key to use with Client Assertion.
    /// </summary>
    public SecurityKey ClientAssertionSecurityKey { get; set; }

    /// <summary>
    /// Algorithm for the Security Key to use with Client Assertion.
    /// </summary>
    public string ClientAssertionSecurityKeyAlgorithm { get; set; }

    /// <summary>
    /// What <see cref="JwtSignatureAlgorithm"/> is used to verify the signature of Id Tokens.
    /// </summary>
    public JwtSignatureAlgorithm SigningAlgorithm { get; set; }

    /// <summary>
    /// Optional nonce to validate against the nonce claim in a returned ID token.
    /// </summary>
    /// <remarks>
    /// When set, the nonce claim in the returned ID token must exactly match this value.
    /// Leave null (the default) to skip nonce validation.
    /// </remarks>
    public string? Nonce { get; set; }
}
