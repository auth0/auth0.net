using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.SelfServiceProfiles
{
    public class SelfServiceProfile : SelfServiceProfileBase
    {
        /// <summary>
        /// The unique ID of the self-service profile.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// The time when this self-service Profile was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// The time when this self-service Profile was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}