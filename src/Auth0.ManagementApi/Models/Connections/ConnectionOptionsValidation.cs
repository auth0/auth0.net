using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Connections
{
    /// <summary>
    /// Options for validation
    /// </summary>
    public class ConnectionOptionsValidation
    {
        [JsonProperty("username")]
        public ConnectionOptionsUserName UserName { get; set; }
    }

    public class ConnectionOptionsUserName
    {
        [JsonProperty("min")]
        public int Min { get; set; }
        
        [JsonProperty("max")]
        public int Max { get; set; }
    }
}