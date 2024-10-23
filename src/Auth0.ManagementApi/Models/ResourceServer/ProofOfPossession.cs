using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Proof-of-Possession configuration for access tokens
    /// </summary>
    public class ProofOfPossession
    {
        /// <summary>
        /// Whether the use of Proof-of-Possession is required for the resource server
        /// </summary>
        [JsonProperty("required")]
        public bool? Required { get; set; }
        
        /// <summary>
        /// <inheritdoc cref="Auth0.ManagementApi.Models.Mechanism"/>
        /// </summary>
        [JsonProperty("mechanism")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Mechanism Mechanism { get; set; }
    }
}