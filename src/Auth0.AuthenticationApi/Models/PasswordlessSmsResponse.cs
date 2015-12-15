using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents the response from a Passwordless SMS request.
    /// </summary>
    public class PasswordlessSmsResponse
    {
        /// <summary>
        /// Gets or sets the identifier of the request.
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }

        /// <summary>
        /// The phone number to which the code was sent.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The language is which the message was sent.
        /// </summary>
        [JsonProperty("request_language")]
        public object RequestLanguage { get; set; }
    }
}