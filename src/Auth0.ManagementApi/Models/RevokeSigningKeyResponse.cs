using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class RevokeSigningKeyResponse
    {
        /// <summary>
        /// The key id of the revoked signing key
        /// </summary>
        [JsonProperty("kid")]
        public string Kid { get; set; }

        /// <summary>
        /// The public certificate of the revoked signing key
        /// </summary>
        [JsonProperty("cert")]
        public string Cert { get; set; }
    }
}