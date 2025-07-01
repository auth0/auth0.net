using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Phone provider configuration schema
/// </summary>
public class BrandingPhoneProviderBase
{
    /// <summary>
    /// Name of the phone notification provider
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
        
    /// <summary>
    /// Whether the provider is enabled (false) or disabled (true).
    /// </summary>
    [JsonProperty("disabled")]
    public bool? Disabled { get; set; }
        
    [JsonProperty("configuration")]
    public dynamic Configuration { get; set; }
}
    
/// <summary>
/// Provider credentials required to use authenticate to the provider.
/// </summary>
public class BrandingCredential
{
    [JsonProperty("auth_token")]
    public string AuthToken { get; set; }
}