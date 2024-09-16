using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class ScimToken : ScimTokenBase
    {
        /// <summary>
        /// The token's last used at timestamp
        /// </summary>
        [JsonProperty("last_used_at")]
        public string LastUsedAt { get; set; }
    }
}