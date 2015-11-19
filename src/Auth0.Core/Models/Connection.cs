using Newtonsoft.Json;

namespace Auth0.Core.Models
{
    public class Connection : ConnectionBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("strategy")]
        public string Strategy { get; set; }
    }
}