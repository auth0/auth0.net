using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents a request to create a new custom domain.
    /// </summary>
    public class CustomDomainCreateRequest
    {
        /// <summary>
        /// The custom domain.
        /// </summary>
        [JsonProperty("domain")]
        public string Domain { get; set; }

        /// <summary>
        /// The custom domain provisioning type.
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CustomDomainCertificateProvisioning Type { get; set; }

        /// <summary>
        /// The custom domain verification method.
        /// </summary>
        [JsonProperty("verification_method")]
        public string VerificationMethod { get; set; }
        
        /// <summary>
        /// Possible values: [recommended, compatible]
        /// recommended includes TLS 1.2
        /// </summary>
        [JsonProperty("tls_policy")]
        public string TlsPolicy { get; set; }
        
        /// <summary>
        /// Possible values: [true-client-ip, cf-connecting-ip, x-forwarded-for, x-azure-clientip, null]
        /// HTTP header to fetch client IP header. Ex: CF-Connecting-IP, X-Forwarded-For or True-Client-IP.
        /// </summary>
        [JsonProperty("custom_client_ip_header")]
        public string CustomClientIpHeader { get; set; }
    }
}