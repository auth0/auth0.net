using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// The custom domain verification method.
    /// </summary>
    public class CustomDomainVerificationMethod
    {
        /// <summary>
        /// Domain verification method. ("cname" or "txt")
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Value used to verify the domain.
        /// </summary>
        [JsonProperty("record")]
        public string Record { get; set; }

        /// <summary>
        /// The name of the txt record for verification.
        /// </summary>
        [JsonProperty("domain")]
        public string Domain { get; set; }
    }
}