using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Client.Models
{
    public class SignupUserResponse
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("username")]
        public object Username { get; set; }
    }
}