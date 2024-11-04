using System;
using System.Net.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models.Keys
{
    /// <summary>
    /// Represents and Encryption Key
    /// </summary>
    public class EncryptionKey
    {
        /// <summary>
        /// Key ID
        /// </summary>
        [JsonProperty("kid")]
        public string Kid { get; set; }

        /// <inheritdoc cref="EncryptionKeyType"/>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EncryptionKeyType Type { get; set; }

        /// <inheritdoc cref="EncryptionKeyState"/>
        [JsonProperty("state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EncryptionKeyState State { get; set; }

        /// <summary>
        /// Key creation timestamp
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Key update timestamp
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// ID of the parent wrapping key.
        /// </summary>
        [JsonProperty("parent_kid")]
        public string ParentKid { get; set; }

        /// <summary>
        /// Public key in PEM format
        /// </summary>
        [JsonProperty("public_key")]
        public string PublicKey { get; set; }
    }
}