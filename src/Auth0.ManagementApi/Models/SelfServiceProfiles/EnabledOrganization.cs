using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.SelfServiceProfiles
{
    /// <summary>
    /// List of organizations that the connection will be enabled for.
    /// </summary>
    public class EnabledOrganization
    {
        /// <summary>
        /// Organization identifier
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }

        /// <summary>
        /// Whether or not users that login will automatically be granted membership to the organization.
        /// </summary>
        [JsonProperty("assign_membership_on_login")]
        public bool AssignMembershipOnLogin { get; set; }

        /// <summary>
        /// Determines whether a connection should be displayed on this organization’s login prompt.
        /// </summary>
        [JsonProperty("show_as_button")]
        public bool ShowAsButton { get; set; }
    }
}