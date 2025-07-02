using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

public class TokenQuota
{
    /// <summary>
    /// This defines the fields that control the token quota
    /// </summary>
    [JsonProperty("client_credentials")]
    public Quota ClientCredentials { get; set; }
}