using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Base class for custom domain responses.
    /// </summary>
    public abstract class CustomDomainBase
    {
        /// <summary>
        /// The id of the custom domain.
        /// </summary>
        [JsonProperty("custom_domain_id")]
        public string CustomDomainId { get; set; }

        /// <summary>
        /// The custom domain.
        /// </summary>
        [JsonProperty("domain")]
        public string Domain { get; set; }

        /// <summary>
        /// The intermediate address.
        /// </summary>
        [JsonProperty("origin_domain_name")]
        public string OriginDomainName { get; set; }

        /// <summary>
        /// true if the domain was marked as "primary", false otherwise.
        /// </summary>
        [JsonProperty("primary")]
        public bool Primary { get; set; }

        /// <summary>
        /// The custom domain configuration status.
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CustomDomainStatus Status { get; set; }

        /// <summary>
        /// The custom domain provisioning type.
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CustomDomainCertificateProvisioning Type { get; set; }

        /// <summary>
        /// The custom domain verification methods.
        /// </summary>
        [JsonProperty("verification")]
        public CustomDomainVerification Verification { get; set; }
        
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