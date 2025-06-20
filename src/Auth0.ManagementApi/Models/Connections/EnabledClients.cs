using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Connections;

public class EnabledClients
{
    /// <summary>
    /// The client ID
    /// </summary>
    [JsonProperty("client_id")]
    public string? ClientId { get; set; }
};