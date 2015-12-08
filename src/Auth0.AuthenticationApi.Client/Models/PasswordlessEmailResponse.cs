using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Client.Models
{
    public class PasswordlessEmailResponse
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }
    }
}