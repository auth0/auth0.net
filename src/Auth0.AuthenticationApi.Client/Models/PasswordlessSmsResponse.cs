using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Client.Models
{
    public class PasswordlessSmsResponse
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("request_language")]
        public object RequestLanguage { get; set; }
    }
}