using System;
using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Client.Models
{
    public class AuthenticationRequest
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("connection")]
        public string Connection { get; set; }

        [JsonProperty("device")]
        public string Device { get; set; }

        [JsonProperty("grant_type")]
        public string GrantType { get; set; }

        [JsonProperty("id_token")]
        public string IdToken { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }
}