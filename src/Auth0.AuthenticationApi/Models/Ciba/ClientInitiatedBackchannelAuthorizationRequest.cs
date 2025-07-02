using System.Collections.Generic;

using Microsoft.IdentityModel.Tokens;

namespace Auth0.AuthenticationApi.Models.Ciba;

/// <summary>
/// Contains information required for initiating a CIBA authorization request.
/// </summary>
public class ClientInitiatedBackchannelAuthorizationRequest : IClientAuthentication
{
    /// <inheritdoc cref="IClientAuthentication.ClientId"/>
    public string ClientId { get; set; }
        
    /// <inheritdoc cref="IClientAuthentication.ClientSecret"/>
    public string ClientSecret { get; set; }
        
    /// <inheritdoc cref="IClientAuthentication.ClientAssertionSecurityKey"/>
    public SecurityKey ClientAssertionSecurityKey { get; set; }
        
    /// <inheritdoc cref="IClientAuthentication.ClientAssertionSecurityKeyAlgorithm"/>
    public string ClientAssertionSecurityKeyAlgorithm { get; set; }
        
    /// <summary>
    /// A human-readable string intended to be displayed on both the device calling /bc-authorize and
    /// the user’s authentication device (e.g. phone) to ensure the user is approving the correct request.
    /// For example: “ABC-123-XYZ”.
    /// </summary>
    public string BindingMessage { get; set; }
        
    /// <inheritdoc cref="Ciba.LoginHint"/>
    public LoginHint LoginHint { get; set; }
        
    /// <summary>
    /// A space-separated list of OIDC and custom API scopes.
    /// </summary>
    public string Scope { get; set; }
        
    /// <summary>
    /// If you require an access token for an API, pass the unique identifier of the target API you want to access here
    /// </summary>
    public string Audience { get; set; }
        
    /// <summary>
    /// Used to configure a custom expiry time for this request.
    /// </summary>
    public int? RequestExpiry { get; set; }
        
    /// <summary>
    /// Any additional properties to use.
    /// </summary>
    public IDictionary<string, string> AdditionalProperties { get; set; } = new Dictionary<string, string>();
}