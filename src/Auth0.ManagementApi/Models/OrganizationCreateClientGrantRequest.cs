using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationCreateClientGrantRequest
    {
        /// <summary>
        /// A Client Grant ID to add to the organization. 
        /// </summary>
        [JsonProperty("grant_id")]
        public string GrantId { get; set; } 
    }
}