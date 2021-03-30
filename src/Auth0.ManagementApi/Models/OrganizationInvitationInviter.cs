using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationInvitationInviter
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}