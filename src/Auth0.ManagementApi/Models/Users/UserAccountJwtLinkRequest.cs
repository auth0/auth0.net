using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class UserAccountJwtLinkRequest
    {

        /// <summary>
        /// Gets or sets the JWT of the secondary account being linked.
        /// </summary>
        [JsonProperty("link_with")]
        public string LinkWith { get; set; }

    }

}