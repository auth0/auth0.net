using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

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

        [OnError]
        internal void OnError(StreamingContext context, ErrorContext errorContext)
        {
            // When the GuardianFactorName enum can not be serialized, set the value to null (as name is a nullable property)
            // This ensures the code does not break when new factor names are added in Auth0 Server that are not part of the enum yet.
            if (errorContext.Member != null && errorContext.Member.ToString() == "name")
            {
                errorContext.Handled = true;
            }
        }
    }
}
