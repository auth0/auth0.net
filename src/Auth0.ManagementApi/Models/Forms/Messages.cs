using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Forms
{
    public class Messages
    {
        [JsonProperty("errors")]
        public dynamic Errors { get; set; }
        
        [JsonProperty("custom")]
        public dynamic Custom { get; set; }
    }
}