using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Keys
{
    /// <summary>
    /// Contains information required for importing an encryption key.
    /// </summary>
    public class EncryptionKeyImportRequest
    {
        /// <summary>
        /// Encryption key ID
        /// </summary>
        public string Kid { get; set; }
        
        /// <summary>
        /// Base64 encoded ciphertext of key material wrapped by public wrapping key.
        /// </summary>
        [JsonProperty("wrapped_key")]
        public string WrappedKey { get; set; }
    }
}