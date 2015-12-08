using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Client.Models
{
    public abstract class TokenBase
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}