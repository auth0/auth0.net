using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class PasswordChangeTicketRequest
    {
        /// <summary>
        /// The user will be redirected to this endpoint once the ticket is used.
        /// </summary>
        [JsonProperty("result_url")]
        public string ResultUrl { get; set; }

        /// <summary>
        /// The user ID for which the ticket is to be created.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// The password to set for the user once the ticket is used.
        /// </summary>
        [JsonProperty("new_password")]
        public string NewPassword { get; set; }

        /// <summary>
        /// The connection that provides the identity for which the password is to be changed. If sending this parameter, the <see cref="Email"/> is also required and the <see cref="UserId"/> is invalid.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// The user's email.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

    }

}