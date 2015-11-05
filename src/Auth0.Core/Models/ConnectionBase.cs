using Newtonsoft.Json;

namespace Auth0.Core.Models
{
    public abstract class ConnectionBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("options")]
        public dynamic Options { get; set; }

        [JsonProperty("enabled_clients")]
        public string[] EnabledClients { get; set; }
    }
}