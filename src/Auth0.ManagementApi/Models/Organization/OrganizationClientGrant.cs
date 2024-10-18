using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationClientGrant
    {
        /// <summary>
        /// Gets or sets the identifier for a Client Grant.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        
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
    }
}