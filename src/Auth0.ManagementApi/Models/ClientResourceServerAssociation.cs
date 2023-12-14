using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class ClientResourceServerAssociation
    {
        /// <summary>
        /// The resource server (API) identifier.
        /// </summary>
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// The scopes granted to the client to access the resource server.
        /// </summary>
        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }
    }
}
