using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class Credential
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
        /// The kid of the credential
        /// </summary>
        [JsonProperty("kid")]
        public string Kid { get; set; }
        /// <summary>
        /// The id of the credential
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// Algorithm which will be used with the credential. Supported algorithms: RS256,RS384,PS256
        /// </summary>
        [JsonProperty("alg")]
        public string Algorithm { get; set; }
        /// <summary>
        /// The DateTime when the credential was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// The DateTime when the credential was updated
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// The DateTime when the credential expires
        /// </summary>
        [JsonProperty("expires_at")]
        public DateTime? ExpiresAt { get; set; }
    }
}