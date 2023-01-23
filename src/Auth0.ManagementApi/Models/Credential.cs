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
        /// The thumbprint of the credential
        /// </summary>
        [JsonProperty("thumbprint")]
        public string Thumbprint { get; set; }
        /// <summary>
        /// The DateTime when the credential was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}