using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Connections;

/// <summary>
/// Contains information required to update <see cref="EnabledClients"/>. 
/// </summary>
public class EnabledClientsUpdateRequest
{
    /// <summary>
    /// The client_id of the client to be the subject to change status
    /// </summary>
    [JsonProperty("client_id")]
    public string ClientId { get; set; }
    
    /// <summary>
    /// Whether the connection is enabled or not for this client_id
    /// </summary>
    [JsonProperty("status")]
    public bool? Status { get; set; }
};