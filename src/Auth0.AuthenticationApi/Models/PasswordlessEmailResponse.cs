using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a Passwordless email response.
    /// </summary>
    public class PasswordlessEmailResponse
    {
        /// <summary>
        /// Identifier of this request.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Email to which the request was sent.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}