using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

public class DefaultTokenQuota
{
    /// <summary>
    /// This defines the fields that control the token quota for Clients
    /// </summary>
    [JsonProperty("clients")]
    public TokenQuota Clients { get; set; }

    /// <summary>
    /// This defines the fields that control the token quota for Organizations
    /// </summary>
    [JsonProperty("organizations")]
    public TokenQuota Organizations { get; set; }
}