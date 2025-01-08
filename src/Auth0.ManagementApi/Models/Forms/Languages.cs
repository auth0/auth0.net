using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Forms
{
    public class Languages
    {
        [JsonProperty("primary")]
        public string Primary { get; set; }
        
        [JsonProperty("default")]
        public string Default { get; set; }
    }
}