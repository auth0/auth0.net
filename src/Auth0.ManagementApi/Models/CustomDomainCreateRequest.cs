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
    }
}