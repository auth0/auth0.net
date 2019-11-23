using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents the response from a Passwordless SMS request.
    /// </summary>
    public class PasswordlessSmsResponse
    {
        /// <summary>
        /// Unique identifier of the request.
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }

        /// <summary>
        /// Phone number to which the code was sent.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Language the message sent was written in.
        /// </summary>
        [JsonProperty("request_language")]
        public object RequestLanguage { get; set; }
    }
}