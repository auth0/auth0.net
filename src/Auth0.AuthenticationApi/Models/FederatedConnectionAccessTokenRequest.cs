using Microsoft.IdentityModel.Tokens;

namespace Auth0.AuthenticationApi.Models;

/// <summary>
/// Represents a request to exchange an Auth0 token for an access token issued by one of
/// Auth0's federated connections (Token Vault), using the Auth0 token-exchange grant
/// <c>urn:auth0:params:oauth:grant-type:token-exchange:federated-connection-access-token</c>.
/// </summary>
/// <remarks>
/// The client must be a private client. The subject token may be an Auth0 access token
/// (<see cref="TokenType.AccessToken"/>) or refresh token (<see cref="TokenType.RefreshToken"/>).
/// </remarks>
public class FederatedConnectionAccessTokenRequest : IClientAuthentication
{
    /// <summary>
    /// The Auth0 token being exchanged. This may be a valid Auth0 access token or refresh token.
    /// Required.
    /// </summary>
    public string SubjectToken { get; set; }

    /// <summary>
    /// An identifier that indicates the type of <see cref="SubjectToken"/>, as a URN.
    /// Either <see cref="TokenType.AccessToken"/> or <see cref="TokenType.RefreshToken"/>. Required.
    /// </summary>
    public string SubjectTokenType { get; set; }

    /// <summary>
    /// The federated connection to obtain the access token for (for example
    /// <c>google-oauth2</c>). Required.
    /// </summary>
    public string Connection { get; set; }

    /// <summary>
    /// Optional user ID of the current user within the IdP named by <see cref="Connection"/>.
    /// For example, if the connection is <c>google-oauth2</c>, this is the Google user ID.
    /// </summary>
    public string LoginHint { get; set; }

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
