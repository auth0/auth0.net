using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationConnection
    {
        /// <summary>
        /// ID of the connection.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

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
        
        /// <summary>
        /// Determines whether organization signup should be enabled for this organization connection.
        /// </summary>
        [JsonProperty("is_signup_enabled")]
        public bool IsSignUpEnabled { get; set; }

        /// <summary>
        /// Information on the enabled connection
        /// </summary>
        [JsonProperty("connection")]
        public OrganizationConnectionInfo Connection { get; set; }
    }
}
