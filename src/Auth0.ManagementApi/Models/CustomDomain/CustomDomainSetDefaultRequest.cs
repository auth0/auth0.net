using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Represents a request to set the default custom domain for a tenant.
/// </summary>
public class CustomDomainSetDefaultRequest
{
    /// <summary>
    /// The domain to set as default. 
    /// Must match a verified custom domain or the canonical domain.
    /// </summary>
    [JsonProperty("domain")]
    public string Domain { get; set; }
}
