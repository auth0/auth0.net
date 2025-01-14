using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Flow
{
    /// <summary>
    /// Contains information required for updating a flow
    /// </summary>
    public class FlowUpdateRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("actions")]
        public dynamic Actions { get; set; }
    }
}