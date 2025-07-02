using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions;

/// <summary>
/// Allowable options for this param.
/// </summary>
public class ActionOption
{
    /// <summary>
    /// The value of an option that will be used within the application.
    /// </summary>
    [JsonProperty("value")]
    public string Value { get; set; }
        
    /// <summary>
    /// The display value for an option that will be used within the application.
    /// </summary>
    [JsonProperty("label")]
    public string Label { get; set; }
}