using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Flow;

public class FlowVaultConnectionCreateRequest
{
    [JsonProperty("app_id")]
    public string AppId { get; set; }
        
    [JsonProperty("setup")]
    public dynamic Setup { get; set; }
        
    [JsonProperty("name")]
    public string Name { get; set; }
}