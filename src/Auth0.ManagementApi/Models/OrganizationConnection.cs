using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationConnection
    {
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }
        [JsonProperty("assign_membership_on_login")]
        public bool AssignMembershipOnLogin { get; set; }

    }
}
