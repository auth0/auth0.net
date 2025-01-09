using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class CustomDomainUpdateRequest
    {
        /// <summary>
        /// Possible values: [recommended]
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