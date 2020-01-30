using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Connection object as returned from API calls.
    /// </summary>
    public class Connection : ConnectionBase
    {
        /// <summary>
        /// The connection's identifier.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Connection name used in login screen.
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Whether the connection is domain level (true), or not (false).
        /// </summary>
        [JsonProperty("is_domain_connection")]
        public bool IsDomainConnection { get; set; }

        /// <summary>
        /// The identity provider identifier for the connection.
        /// </summary>
        [JsonProperty("strategy")]
        public string Strategy { get; set; }
    }
}