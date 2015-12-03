using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Client.Models
{
    public class AccessToken : TokenBase
    {
        [JsonProperty("id_token")]
        public string IdToken { get; set; }
    }
}