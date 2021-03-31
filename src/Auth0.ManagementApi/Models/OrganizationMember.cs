using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationMember
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("picture")]
        public string Picture { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
