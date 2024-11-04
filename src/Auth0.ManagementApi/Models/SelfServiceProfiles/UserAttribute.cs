using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.SelfServiceProfiles
{
    /// <summary>
    /// Attribute to be mapped that will be shown to the user during the SS-SSO workflow.
    /// </summary>
    public class UserAttribute
    {
        /// <summary>
        /// Identifier of this attribute.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Description of this attribute
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        
        /// <summary>
        /// Determines if the attribute is required.
        /// </summary>
        [JsonProperty("is_optional")]
        public bool? IsOptional { get; set; }
    }
}