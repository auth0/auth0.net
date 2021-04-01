using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationConnectionUpdateRequest
    {
        /// <summary>
        /// Whether or not users that login will automatically be granted membership to the organization.
        /// </summary>
        [JsonProperty("assign_membership_on_login")]
        public bool AssignMembershipOnLogin { get; set; }
    }
}
