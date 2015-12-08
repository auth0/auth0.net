using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Client.Models
{
    public class UserMaintenanceRequestBase
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("connection")]
        public string Connection { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}