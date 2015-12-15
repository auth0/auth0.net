using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class UserAccountLinkRequest
    {

        /// <summary>
        /// Gets or sets the type of identity provider of the secondary account being linked.
        /// </summary>
        [JsonProperty("provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the connection of the secondary account being linked.
        /// </summary>
        /// <remarks>
        ///  This is optional and may be useful in the case of having more than a database connection for the 'auth0' provider.
        /// </remarks>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// Gets or sets the user's identitifer of the secondary account being linked.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

    }

}