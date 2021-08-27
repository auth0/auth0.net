using Newtonsoft.Json;

namespace Auth0.ManagementApi.Actions
{
    public class ActionSupportedTrigger
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}