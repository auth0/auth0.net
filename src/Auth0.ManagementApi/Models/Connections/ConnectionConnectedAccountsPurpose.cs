using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Connections;

/// <summary>
/// Configure the purpose of a connection to be used for connected accounts and Token Vault.
/// </summary>
public class ConnectionConnectedAccountsPurpose
{
    [JsonProperty("active")]
    public required bool Active { get; set; }
    
    [JsonProperty("cross_app_access")]
    public bool? CrossAppAccess { get; set; }
}