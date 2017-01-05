using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class EncryptionKey
    {
        /// <summary>
        /// Encryption certificate
        /// </summary>
        [JsonProperty("cert")]
        public string Certificate { get; set; }

        /// <summary>
        /// Encryption public key
        /// </summary>
        [JsonProperty("pub")]
        public string PublicKey { get; set; }

        /// <summary>
        /// The subject of the Enryption key
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }
    }
}