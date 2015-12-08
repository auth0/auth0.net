using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Client.Models
{
    public class PasswordlessEmailRequest
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("send")]
        public PasswordlessEmailRequestType Type { get; set; }

        [JsonProperty("authParams")]
        public string AuthenticationParameters { get; set; }
    }
}