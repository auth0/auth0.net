using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// mTLS configuration.
/// </summary>
public class TenantMtls
{
    /// <summary>
    /// If true, enables mTLS endpoint aliases
    /// </summary>
    [JsonProperty("enable_endpoint_aliases")]
    public bool? EnableEndpointAliases { get; set; }
}