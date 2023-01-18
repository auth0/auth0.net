using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class Credential
    {
        [JsonProperty("credential_type")]
        public string CredentialType { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("kid")]
        public string Kid { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("thumbprint")]
        public string Thumbprint { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}