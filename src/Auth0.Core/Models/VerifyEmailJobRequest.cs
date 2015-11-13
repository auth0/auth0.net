using Newtonsoft.Json;

namespace Auth0.Core.Models
{
    public class VerifyEmailJobRequest
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}