using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Flow
{
    public class FlowVaultConnectionUpdateRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("setup")]
        public dynamic Setup { get; set; }
    }
}