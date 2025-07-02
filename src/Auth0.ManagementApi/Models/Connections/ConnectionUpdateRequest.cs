using Auth0.ManagementApi.Models.Connections;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Specifies the properties for updating an existing connection.
/// </summary>
public class ConnectionUpdateRequest : ConnectionBase
{
    /// <inheritdoc cref="ConnectionOptions"/> 
    [JsonProperty("options")]
    public dynamic Options { get; set; }
}