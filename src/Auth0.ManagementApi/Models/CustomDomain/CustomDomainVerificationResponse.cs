using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Response when requesting a custom domain verification
    /// </summary>
    public class CustomDomainVerificationResponse : CustomDomainBase
    {
        /// <summary>
        /// The CNAME API key header value.
        /// </summary>
        [JsonProperty("cname_api_key")]
        public string CnameApiKey { get; set; }
    }
}
