using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Structure for creating a new client credential
    /// </summary>
    public class ClientCredentialCreateRequest
    {
        /// <summary>
        /// The type of the credential
        /// </summary>
        [JsonProperty("credential_type")]
        public string CredentialType { get; set; }
        /// <summary>
        /// The name of the credential
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The value of the credential in PEM format.
        /// </summary>
        [JsonProperty("pem")]
        public string Pem { get; set; }
        /// <summary>
        /// Algorithm which will be used with the credential. Can be one of RS256, RS384, PS256. If not specified, RS256 will be used.
        /// </summary>
        [JsonProperty("alg")]
        public string Algorithm { get; set; }
        /// <summary>
        /// Parse expiry from x509 certificate. If true, attempts to parse the expiry date from the provided PEM.
        /// </summary>
        [JsonProperty("parse_expiry_from_cert")]
        public bool ParseExpiryFromCert { get; set; }
        /// <summary>
        /// The date representing the expiration of the credential. If not specified (not recommended), the credential never expires.
        /// </summary>
        [JsonProperty("expires_at")]
        public DateTime? ExpiresAt { get; set; }
    }
}