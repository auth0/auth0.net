using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    public class GuardianFactor
    {
        /// <summary>
        /// States if this factor is enabled.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// The factor name.
        /// </summary>
        [JsonProperty("name")]
        [JsonConverter(typeof(StringEnumConverter))]
        public GuardianFactorName? Name { get; set; }

        /// <summary>
        /// For factors with trial limits (e.g. SMS) states if those limits have been exceeded.
        /// </summary>
        [JsonProperty("trial_expired")]
        public bool? IsTrialExpired { get; set; }
    }
}
