using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Flow
{
    /// <summary>
    /// Contains information required for creating a new flow
    /// </summary>
    public class FlowCreateRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("actions")]
        public dynamic Actions { get; set; }
    }
}