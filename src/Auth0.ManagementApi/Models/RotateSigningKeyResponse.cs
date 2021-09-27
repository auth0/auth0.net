using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class RotateSigningKeyResponse
    {
        /// <summary>
        /// The key id of the next signing key
        /// </summary>
        [JsonProperty("kid")]
        public string Kid { get; set; }

        /// <summary>
        /// The public certificate of the next signing key
        /// </summary>
        [JsonProperty("cert")]
        public string Cert { get; set; }
    }
}