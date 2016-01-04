using Newtonsoft.Json;

namespace Auth0.Core
{

    /// <summary>
    /// 
    /// </summary>
    public class Connection : ConnectionBase
    {

        /// <summary>
        /// The connection's identifier
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The type of the connection, related to the identity provider.
        /// </summary>
        [JsonProperty("strategy")]
        public string Strategy { get; set; }

    }

}