using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Base class for Client Grants
    /// </summary>
    public class ClientGrantBase
    {
        /// <summary>
        /// Gets or sets the audience
        /// </summary>
        [JsonProperty("audience")]
        public string Audience { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the <see cref="Client"/>
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

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