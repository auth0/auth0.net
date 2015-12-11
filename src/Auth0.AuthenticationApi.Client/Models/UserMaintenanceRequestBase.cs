using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Client.Models
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
        [JsonProperty("Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user's password.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}