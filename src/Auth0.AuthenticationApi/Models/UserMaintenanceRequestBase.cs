using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Base class for user maintenance requests.
    /// </summary>
    public class UserMaintenanceRequestBase
    {
        /// <summary>
        /// Gets or sets the client (app) identifier.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        [JsonProperty("connection")]
        public string Connection { get; set; }

        /// <summary>
        /// Gets or sets the user's email address.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}