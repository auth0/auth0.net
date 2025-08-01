using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.SelfServiceProfiles;

/// <summary>
/// Configuration for the setup of Provisioning in the self-service flow.
/// </summary>
public class ProvisioningConfig
{
    /// <summary>
    /// The scopes of the SCIM tokens generated during the self-service flow.
    /// </summary>
    [JsonProperty("scopes")]
    public string[] Scopes { get; set; } 
    
    /// <summary>
    /// Lifetime of the tokens in seconds. Must be greater than 900.
    /// If not provided, the tokens don't expire.
    /// </summary>
    [JsonProperty("token_lifetime")]
    public int? TokenLifetime { get; set; }
}