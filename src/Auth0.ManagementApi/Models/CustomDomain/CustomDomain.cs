using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Represents a Custom Domain
/// </summary>
public class CustomDomain : CustomDomainBase
{
    /// <summary>
    /// Indicates whether this is the default custom domain.
    /// There can only be one default custom domain per tenant.
    /// </summary>
    [JsonProperty("is_default")]
    public bool? IsDefault { get; set; }
}