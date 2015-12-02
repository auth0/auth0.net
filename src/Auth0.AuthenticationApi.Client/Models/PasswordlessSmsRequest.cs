using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Client.Models
{
    public class PasswordlessSmsRequest
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}