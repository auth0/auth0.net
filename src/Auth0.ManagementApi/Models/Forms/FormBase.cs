using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Forms;

public class FormBase
{
    [JsonProperty("id")]
    public string Id { get; set; }
        
    [JsonProperty("name")]
    public string Name { get; set; }
        
    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }
        
    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }
        
    [JsonProperty("embedded_at")]
    public DateTime EmbeddedAt { get; set; }
        
    [JsonProperty("submitted_at")]
    public DateTime SubmittedAt { get; set; }
}