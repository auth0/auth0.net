using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Forms;

public class Node
{
    /// <summary>
    /// format: format-custom-identifier
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }
        
    [JsonProperty("type")]
    public string Type { get; set; }
        
    [JsonProperty("coordinates")]
    public Coordinates Coordinates { get; set; }
        
    [JsonProperty("alias")]
    public string Alias { get; set; }
        
    [JsonProperty("config")]
    public dynamic Config { get; set; }
}