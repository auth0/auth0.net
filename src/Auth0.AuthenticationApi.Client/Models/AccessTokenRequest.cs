using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Client.Models
{
    public class AccessTokenRequest
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("connection")]
        public string Connection { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }
    }
}