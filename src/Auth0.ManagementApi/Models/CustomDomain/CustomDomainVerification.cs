using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// The custom domain verification methods.
    /// </summary>
    public class CustomDomainVerification
    {
        /// <summary>
        /// The custom domain verification methods.
        /// </summary>
        [JsonProperty("methods")]
        public CustomDomainVerificationMethod[] Methods { get; set; }
    }
}