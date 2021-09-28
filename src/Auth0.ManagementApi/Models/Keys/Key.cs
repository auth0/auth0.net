using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Keys
{

    /// <summary>
    /// An Application Signing Key
    /// </summary>
    public class Key
    {
        /// <summary>
        /// The key id of the signing key
        /// </summary>
        [JsonProperty("kid")]
        public string Kid { get; set; }

        /// <summary>
        /// The public certificate of the signing key
        /// </summary>
        [JsonProperty("cert")]
        public string Cert { get; set; }

        /// <summary>
        /// The public certificate of the signing key in pkcs7 format
        /// </summary>
        [JsonProperty("pkcs7")]
        public string Pkcs7 { get; set; }

        /// <summary>
        /// True if the key is the the current key
        /// </summary>
        [JsonProperty("current")]
        public bool? Current { get; set; }

        /// <summary>
        /// True if the key is the the next key
        /// </summary>
        [JsonProperty("next")]
        public bool? Next { get; set; }

        /// <summary>
        /// True if the key is the the previous key
        /// </summary>
        [JsonProperty("previous")]
        public bool? Previous { get; set; }

        /// <summary>
        /// The date and time when the key became the current key
        /// </summary>
        [JsonProperty("current_since")]
        public DateTime? CurrentSince { get; set; }

        /// <summary>
        /// The date and time when the current key was rotated
        /// </summary>
        [JsonProperty("current_until")]
        public DateTime? CurrentUntil { get; set; }

        /// <summary>
        /// The cert fingerprint
        /// </summary>
        [JsonProperty("fingerprint")]
        public string Fingerprint { get; set; }

        /// <summary>
        /// The cert thumbprint
        /// </summary>
        [JsonProperty("thumbprint")]
        public string Thumbprint { get; set; }

        /// <summary>
        /// True if the key is revoked
        /// </summary>
        [JsonProperty("revoked")]
        public bool? Revoked { get; set; }

        /// <summary>
        /// The date and time when the key was revoked
        /// </summary>
        [JsonProperty("revoked_at")]
        public DateTime? RevokedAt { get; set; }
    }
}