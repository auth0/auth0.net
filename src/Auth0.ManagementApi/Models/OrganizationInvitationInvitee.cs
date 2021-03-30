using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationInvitationInvitee
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}