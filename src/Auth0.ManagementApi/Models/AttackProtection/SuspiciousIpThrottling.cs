using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models.AttackProtection
{
    public class Stage
    {
        public class StageEntry
        {
            /// <summary>
            /// Total number of attempts allowed per day.
            /// </summary>
            [JsonProperty("max_attempts")]
            public int MaxAttempts { get; set; }

            /// <summary>
            /// Interval of time, given in milliseconds, at which new attempts are granted.
            /// </summary>
            [JsonProperty("rate")]
            public int Rate { get; set; }
        }

        /// <summary>
        /// Configuration options that apply before every login attempt.
        /// </summary>
        [JsonProperty("pre-login")]
        public StageEntry PreLogin { get; set; }

        /// <summary>
        /// Configuration options that apply before every user registration attempt.
        /// </summary>
        [JsonProperty("pre-user-registration")]
        public StageEntry PreUserRegistration { get; set; }
    }

    public class SuspiciousIpThrottling
    {
        /// <summary>
        /// Whether or not suspicious IP throttling attack protections are active.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Action to take when a suspicious IP throttling threshold is violated. Possible values: "block", "admin_notification".
        /// </summary>
        [JsonProperty("shields")]
        public IList<string> Shields { get; set; }

        /// <summary>
        /// List of trusted IP addresses that will not have attack protection enforced against them.
        /// </summary>
        [JsonProperty("allowlist")]
        public IList<string> Allowlist { get; set; }

        /// <summary>
        /// Holds per-stage configuration options (max_attempts and rate).
        /// </summary>
        [JsonProperty("stage")]
        public Stage Stage { get; set; }
    }

}
