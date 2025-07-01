using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

public class BrandingPhoneProviderGetRequest
{
    /// <summary>
    /// Whether the provider is enabled (false) or disabled (true).
    /// </summary>
    [JsonProperty("disabled")]
    public bool? Disabled { get; set; }
}