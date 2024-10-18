using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Structure for updating a client credential
    /// </summary>
    public class ClientCredentialUpdateRequest
    {
        /// <summary>
        /// The date representing the expiration of the credential. If not specified (not recommended), the credential never expires.
        /// </summary>
        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }
    }
}