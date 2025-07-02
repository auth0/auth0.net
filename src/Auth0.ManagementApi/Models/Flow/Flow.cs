using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Flow;

/// <summary>
/// Represents a Flow
/// </summary>
public class Flow
{
    /// <summary>
    /// format:flow-id
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }
        
    [JsonProperty("name")]
    public string Name { get; set; }
        
    [JsonProperty("actions")]
    public dynamic Actions { get; set; }
        
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }
        
    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
        
    [JsonProperty("executed_at")]
    public DateTime? ExecutedAt { get; set; }
}