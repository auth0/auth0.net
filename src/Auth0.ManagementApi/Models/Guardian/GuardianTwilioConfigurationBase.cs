using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class GuardianTwilioConfigurationBase
    {
        /// <summary>
        /// Number from which the message is sent.
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Copilot SID.
        /// </summary>
        [JsonProperty("messaging_service_sid")]
        public string MessagingServiceSid { get; set; }

        /// <summary>
        /// Twilio Authentication token.
        /// </summary>
        [JsonProperty("auth_token")]
        public string AuthToken { get; set; }

        /// <summary>
        /// Twilio SID.
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; set; }
    }
}