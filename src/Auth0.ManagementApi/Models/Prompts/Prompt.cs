using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Prompts
{
    /// <summary>
    /// Represents Prompt Settings.
    /// </summary>
    public class Prompt
    {
        /// <summary>
        /// Which login experience to use. Can be new or classic
        /// </summary>
        [JsonProperty("universal_login_experience")]
        public string UniversalLoginExperience { get; set; }

        /// <summary>
        /// Whether identifier first is enabled or not.
        /// </summary>
        [JsonProperty("identifier_first")]
        public bool IdentifierFirst { get; set; }

        /// <summary>
        /// Use WebAuthn with Device Biometrics as the first authentication factor
        /// </summary>
        [JsonProperty("webauthn_platform_first_factor")]
        public bool WebAuthnPlatformFirstFactor { get; set; }
    }
}
