using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Specifies the user and client required in sending an email address verification link.
    /// </summary>
    public class VerifyEmailJobRequest
    {
        /// <summary>
        /// The identifier of the user to whom the email will be sent.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// The id of the client, if not provided the global one will be used
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
    }
}