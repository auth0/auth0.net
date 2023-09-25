using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Base class for connections which includes both request and responses.
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
        /// The text used on the login button.
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Optional metadata for the connection.
        /// </summary>
        [JsonProperty("metadata")]
        public dynamic Metadata { get; set; }

        /// <summary>
        /// The options for the connection.
        /// </summary>
        [JsonProperty("options")]
        public dynamic Options { get; set; }

        /// <summary>
        /// Defines the realms for which the connection will be used (ie: email domains). If the array is empty or the property is not specified, the connection name will be added as realm. Maximum of 10 items.
        /// </summary>
        [JsonProperty("realms")]
        public string[] Realms { get; set; }

        /// <summary>
        /// The identifiers of the clients for which the connection is to be enabled. If the array is empty or the property is not specified, no clients are enabled.
        /// </summary>
        [JsonProperty("enabled_clients")]
        public string[] EnabledClients { get; set; }

        /// <summary>
        /// True to show this connection as a button on login, false otherwise.
        /// </summary>
        [JsonProperty("show_as_button")]
        public bool? ShowAsButton { get; set; }
      
        /// <summary>
        /// Whether the connection is domain level (true), or not (false).
        /// </summary>
        [JsonProperty("is_domain_connection")]
        public bool IsDomainConnection { get; set; }
    }
}