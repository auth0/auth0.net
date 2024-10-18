using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Request structure for updating a new Client Grant
    /// </summary>
    public class ClientGrantUpdateRequest
    {
        /// <summary>
        /// Gets or sets the list of scopes
        /// </summary>
        [JsonProperty("scope")]
        public List<string> Scope { get; set; }

        /// <summary>
        /// Defines whether organizations can be used with client credentials exchanges for this grant. (defaults to deny when not defined)
        /// </summary>
        /// <remarks>
        /// Possible values: [deny, allow, require]
        /// </remarks>
        [JsonProperty("organization_usage")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrganizationUsage? OrganizationUsage { get; set; }
        
        /// <summary>
        /// If enabled, any organization can be used with this grant. If disabled (default), the grant must be explicitly assigned to the desired organizations.
        /// </summary>
        [JsonProperty("allow_any_organization")]
        public bool? AllowAnyOrganization { get; set; }
    }
}