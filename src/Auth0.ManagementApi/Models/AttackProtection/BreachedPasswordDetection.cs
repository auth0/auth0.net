using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models.AttackProtection
{
    public class BreachedPasswordDetectionStage
    {
        public class StageEntry {
            /// <summary>
            /// Action to take when a breached password is detected. Possible values: "block", "admin_notification".
            /// </summary>
            [JsonProperty("shields")]
            public IList<string> Shields { get; set; }
        }

        /// <summary>
        /// Configuration options that apply before every user registration attempt.
        /// </summary>
        [JsonProperty("pre-user-registration")]
        public StageEntry PreUserRegistration { get; set; }
    }

    public class BreachedPasswordDetection
    {
        /// <summary>
        /// Whether or not breached password detection is active.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Action to take when a breached password is detected. Possible values: "block", "user_notification", "admin_notification".
        /// </summary>
        [JsonProperty("shields")]
        public IList<string> Shields { get; set; }

        /// <summary>
        /// When "admin_notification" is enabled, determines how often email notifications are sent. Possible values: "immediately", "daily", "weekly", "monthly".
        /// </summary>
        [JsonProperty("admin_notification_frequency")]
        public IList<string> AdminNotificationFrequency { get; set; }

        /// <summary>
        /// The subscription level for breached password detection methods. Use "enhanced" to enable Credential Guard. Possible values: "standard", "enhanced".
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; }

        /// <summary>
        /// Holds per-stage configuration options (shields).
        /// </summary>
        [JsonProperty("stage")]
        public BreachedPasswordDetectionStage Stage { get; set; }
    }

}
