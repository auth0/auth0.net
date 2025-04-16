using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class Quota
    {
        /// <summary>
        /// Max number of issued tokens per day.
        /// </summary>
        [JsonProperty("per_day")]
        public int? PerDay { get; set; }

        /// <summary>
        /// Max number of issued tokens per hour.
        /// </summary>
        [JsonProperty("per_hour")]
        public int? PerHour { get; set; }

        /// <summary>
        /// Whether to enforce the rate limit, useful for learning modes as well as disabling specific clients.
        /// </summary>
        [JsonProperty("enforce")]
        public bool? Enforce { get; set; }
    }
}