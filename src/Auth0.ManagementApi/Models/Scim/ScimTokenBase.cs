using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents an SCIM token for an SCIM client.
    /// </summary>
    public class ScimTokenBase
    {
        /// <summary>
        /// The token's identifier
        /// </summary>
        [JsonProperty("token_id")]
        public string TokenId { get; set; }
        
        /// <summary>
        /// The scopes of the scim token
        /// </summary>
        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }
        
        /// <summary>
        /// The token's created at timestamp
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
        
        /// <summary>
        /// The token's valid until at timestamp
        /// </summary>
        [JsonProperty("valid_until")]
        public string ValidUntil { get; set; }
    }
}