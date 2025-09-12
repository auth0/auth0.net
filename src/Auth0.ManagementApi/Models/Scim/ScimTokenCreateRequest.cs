using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Represents the client request to Create <see cref="ScimToken"/>
/// </summary>
public class ScimTokenCreateRequest
{
    /// <summary>
    /// The scopes of the scim token
    /// </summary>
    [JsonProperty("scopes")]
    public string[] Scopes { get; set; }
        
    /// <summary>
    /// Lifetime of the token in seconds. Must be greater than 900 or be null
    /// </summary>
    [JsonProperty("token_lifetime")]
    public int? TokenLifetime { get; set; }
}
