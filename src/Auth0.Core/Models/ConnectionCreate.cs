using Newtonsoft.Json;

namespace Auth0.Core.Models
{
    public class ConnectionCreate : ConnectionBase
    {
        [JsonProperty("strategy")]
        public string Strategy { get; set; }
    }
}