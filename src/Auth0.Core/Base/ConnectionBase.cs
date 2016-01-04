using Newtonsoft.Json;

namespace Auth0.Core
{
    /// <summary>
    /// Base class for connections.
    /// </summary>
    public abstract class ConnectionBase
    {
        /// <summary>
        /// The name of the connection.
        /// </summary>
        /// <remarks>
        /// Must start with an alphanumeric characters and can only contain alphanumeric characters and '-'. Max length 35.
        /// </remarks>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The options for the connection.
        /// </summary>
        [JsonProperty("options")]
        public dynamic Options { get; set; }

        /// <summary>
        /// The identifiers of the clients for which the connection is to be enabled. If the array is empty or the property is not specified, no clients are enabled.
        /// </summary>
        [JsonProperty("enabled_clients")]
        public string[] EnabledClients { get; set; }
    }
}