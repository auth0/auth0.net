using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Forms
{
    public class Redirection
    {
        [JsonProperty("delay")]
        public int Delay { get; set; }
        
        [JsonProperty("target")]
        public string Target { get; set; }
    }
}