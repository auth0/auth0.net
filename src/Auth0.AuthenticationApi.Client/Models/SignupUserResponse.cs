using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Client.Models
{
    public class SignupUserResponse
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("username")]
        public object Username { get; set; }
    }
}