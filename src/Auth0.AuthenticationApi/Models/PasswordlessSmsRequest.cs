using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a Passwordless SMS flow request.
    /// </summary>
    public class PasswordlessSmsRequest
    {
        /// <summary>
        /// Client ID of the application.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Client Secret of the application.
        /// </summary>
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// Phone number to which the code must be sent.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// IP address of the end user this token is requested for for rate limit purposes.
        /// </summary>
        /// <remarks>
        /// See https://auth0.com/docs/connections/passwordless/best-practices#link-accounts for more details.
        /// </remarks>
        [JsonIgnore]
        public string ForwardedForIp { get; set; }
    }
}