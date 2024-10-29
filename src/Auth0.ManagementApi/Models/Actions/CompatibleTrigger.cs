using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// Informs which other trigger supports the same event and api.
    /// </summary>
    public class CompatibleTrigger
    {
        /// <summary>
        /// Possible values: [post-login, credentials-exchange, pre-user-registration, post-user-registration,
        /// post-change-password, send-phone-message, custom-phone-provider, custom-email-provider, iga-approval,
        /// iga-certification, iga-fulfillment-assignment, iga-fulfillment-execution,
        /// password-reset-post-challenge, custom-token-exchange-beta]
        /// An actions extensibility point.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// The version of a trigger. v1, v2, etc
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}