using Newtonsoft.Json;

namespace Auth0.ManagementApi.Actions
{
    public class ActionDependency
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}