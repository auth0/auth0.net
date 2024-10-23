using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Structure for creating a new client credential using TLS Client Auth. 
    /// </summary>
    public class CreateTlsClientAuthCredentials
    {
        /// <summary>
        /// Possible values: [cert_subject_dn]
        /// </summary>
        [JsonProperty("credential_type")]
        public string CredentialType { get; set; }
        
        /// <summary>
        /// The name of the credential
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// PEM-formatted X509 certificate. Must be JSON escaped. Mutually exclusive with subject_dn property.
        /// </summary>
        [JsonProperty("pem")]
        public string Pem { get; set; }
        
        /// <summary>
        /// Subject Distinguished Name. Mutually exclusive with pem property.
        /// </summary>
        [JsonProperty("subject_dn")]
        public string SubjectDistinguishedName { get; set; }
    }
}