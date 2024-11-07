using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Keys
{
    /// <summary>
    /// Represents the WrappingKey
    /// </summary>
    public class WrappingKey
    {
        /// <summary>
        /// Public wrapping key in PEM format
        /// </summary>
        [JsonProperty("public_key")]
        public string PublicKey { get; set; }
        
        /// <summary>
        /// Encryption Algorithm that shall be used to wrap your key material
        /// </summary>
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; }
    }
}