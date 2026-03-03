using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Connections;

/// <summary>
/// Federated Connections Access Tokens
/// </summary>
public class ConnectionOptionsFederatedConnectionsAccessTokens
{
    /// <summary>
    /// Enables refresh tokens and access tokens collection for federated connections
    /// </summary>
    [JsonProperty("active")]
    public bool? Active { get; set; }
}