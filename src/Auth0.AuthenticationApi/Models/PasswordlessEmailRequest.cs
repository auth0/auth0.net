using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to start a Passwordless email flow.
    /// </summary>
    public class PasswordlessEmailRequest
    {
        /// <summary>
        /// Gets or sets the client (app) identifier.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the email to which the link or code must be sent.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the type of response - either code or link.
        /// </summary>
        [JsonProperty("send")]
        public PasswordlessEmailRequestType Type { get; set; }

        /// <summary>
        /// Gets or sets extra authentication parameters.
        /// </summary>
        [JsonProperty("authParams")]
        public string AuthenticationParameters { get; set; }
    }
}