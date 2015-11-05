using Newtonsoft.Json;

namespace Auth0.Core.Models
{
    public class ConnectionCreateRequest : ConnectionBase
    {
        [JsonProperty("strategy")]
        public string Strategy { get; set; }
    }
}