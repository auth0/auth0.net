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
    }
}