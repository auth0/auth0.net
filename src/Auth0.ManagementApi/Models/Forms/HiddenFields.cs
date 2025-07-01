using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Forms;

public class HiddenFields
{
    [JsonProperty("key")]
    public string Key { get; set; }
        
    [JsonProperty("value")]
    public string Value { get; set; }
}