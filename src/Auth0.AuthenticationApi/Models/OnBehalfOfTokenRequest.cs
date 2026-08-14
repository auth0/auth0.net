using Microsoft.IdentityModel.Tokens;

namespace Auth0.AuthenticationApi.Models;

/// <summary>
/// Represents an On-Behalf-Of (OBO) token-exchange request.
/// </summary>
/// <remarks>
/// Exchanges an incoming user access token (<see cref="SubjectToken"/>) for a short-lived,
/// audience-scoped access token that preserves user identity and actor attribution. The
/// SDK sets the grant type and subject-token type internally.
/// </remarks>
public class OnBehalfOfTokenRequest : IClientAuthentication
{
    /// <summary>
    /// The incoming user access token to exchange. Required.
    /// </summary>
    public string SubjectToken { get; set; }

    /// <summary>
    /// The target audience (API identifier) the exchanged token is scoped to. Required.
    /// </summary>
    public string Audience { get; set; }

    /// <summary>
    /// Optional space-delimited scopes for the requested token.
    /// </summary>
    public string Scope { get; set; }

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
}
