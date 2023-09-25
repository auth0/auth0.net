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
        /// The identity provider identifier for the connection.
        /// </summary>
        [JsonProperty("strategy")]
        public string Strategy { get; set; }

        /// <summary>
        /// The provisioning ticket URL for AD / LDAP connections
        /// </summary>
        [JsonProperty("provisioning_ticket_url")]
        public string ProvisioningTicketUrl { get; set; }
    }
}
