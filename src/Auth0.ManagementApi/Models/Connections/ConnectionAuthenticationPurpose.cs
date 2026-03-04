using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Connections;

/// <summary>
/// Configure the purpose of a connection to be used for authentication during login.
/// </summary>
public class ConnectionAuthenticationPurpose
{
    [JsonProperty("active")]
    public required bool Active { get; set; }
}