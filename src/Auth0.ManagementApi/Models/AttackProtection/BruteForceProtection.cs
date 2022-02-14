using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models.AttackProtection
{
    public class BruteForceProtection
    {
        /// <summary>
        /// Whether or not brute force attack protections are active.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Action to take when a brute force protection threshold is violated. Possible values: "block", "user_notification".
        /// </summary>
        [JsonProperty("shields")]
        public IList<string> Shields { get; set; }

        /// <summary>
        /// List of trusted IP addresses that will not have attack protection enforced against them.
        /// </summary>
        [JsonProperty("allowlist")]
        public IList<string> Allowlist { get; set; }

        /// <summary>
        /// Account Lockout: Determines whether or not IP address is used when counting failed attempts. Possible values: "count_per_identifier_and_ip", "count_per_identifier".
        /// </summary>
        [JsonProperty("mode")]
        public string Mode { get; set; }

        /// <summary>
        /// Maximum number of unsuccessful attempts.
        /// </summary>
        [JsonProperty("max_attempts")]
        public int MaxAttempts { get; set; }
    }

}
