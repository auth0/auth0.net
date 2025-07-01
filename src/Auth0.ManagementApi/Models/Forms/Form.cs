using System;
using Newtonsoft.Json;
using Auth0.ManagementApi.Models.Forms;

namespace Auth0.ManagementApi.Models.Forms;

/// <summary>
/// Represents a Form
/// </summary>
public class Form : FormBase
{
    [JsonProperty("messages")]
    public Messages Messages { get; set; }
        
    [JsonProperty("languages")]
    public Languages Languages { get; set; }
        
    [JsonProperty("translations")]
    public dynamic Translations { get; set; }
        
    [JsonProperty("nodes")]
    public Node[] Nodes { get; set; }
        
    [JsonProperty("start")]
    public Start Start { get; set; }
        
    [JsonProperty("ending")]
    public Ending Ending { get; set; }
        
    [JsonProperty("style")]
    public Style Style { get; set; }
}