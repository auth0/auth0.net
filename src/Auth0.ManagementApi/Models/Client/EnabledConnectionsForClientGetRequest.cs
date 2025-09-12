using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Request to get enabled connections for a client
/// </summary>
public class EnabledConnectionsForClientGetRequest
{
    /// <summary>
    /// Provide strategies to only retrieve connections with such strategies
    /// </summary>
    [JsonProperty("strategy")]
    public string[]? Strategy { get; set; }
    
    /// <summary>
    /// A comma separated list of fields to include or exclude (depending on include_fields) from the result, empty to retrieve all fields
    /// </summary>
    [JsonProperty("fields")]
    public string? Fields { get; set; }
    
    /// <summary>
    /// True if the fields specified are to be included in the result, false otherwise (defaults to true)
    /// </summary>
    [JsonProperty("include_fields")]
    public bool? IncludeFields { get; set; }
}