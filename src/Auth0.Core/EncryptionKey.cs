using Newtonsoft.Json;

namespace Auth0.Core
{

    /// <summary>
    /// 
    /// </summary>
    public class EncryptionKey
    {

        /// <summary>
        /// Encryption public key
        /// </summary>
        [JsonProperty("pub")]
        public string PublicKey { get; set; }


        /// <summary>
        /// Encryption certificate
        /// </summary>
        [JsonProperty("cert")]
        public string Certificate { get; set; }
    }
}