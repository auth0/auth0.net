using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a Passwordless email response.
    /// </summary>
    public class PasswordlessEmailResponse
    {
        /// <summary>
        /// The identifier of the request.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The email to which the request was sent.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}