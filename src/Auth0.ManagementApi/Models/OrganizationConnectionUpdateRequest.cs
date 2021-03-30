using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationConnectionUpdateRequest
    {
        [JsonProperty("assign_membership_on_login")]
        public bool AssignMembershipOnLogin { get; set; }

    }
}
