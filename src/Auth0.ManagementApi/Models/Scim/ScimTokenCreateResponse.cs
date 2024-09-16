using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class ScimTokenCreateResponse : ScimTokenBase
    {
        /// <summary>
        /// The SCIM client's token
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}