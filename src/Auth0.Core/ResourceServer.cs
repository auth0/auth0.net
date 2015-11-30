using Newtonsoft.Json;

namespace Auth0.Core
{
    public class ResourceServer
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }
    }
}