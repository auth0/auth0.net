using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Tenant Device Flow configuration.
    /// </summary>
    public class TenantDeviceFlow
    {
        /// <summary>
        /// The character set for generating a User Code.
        /// </summary>
        [JsonProperty("charset")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TenantDeviceFlowCharset Charset { get; set; }

        /// <summary>
        /// The mask used to format the generated User Code to a friendly, readable format with possible spaces or hyphens.
        /// </summary>
        /// <example>****-****</example>
        [JsonProperty("mask")]
        public string Mask { get; set; }
    }
}
