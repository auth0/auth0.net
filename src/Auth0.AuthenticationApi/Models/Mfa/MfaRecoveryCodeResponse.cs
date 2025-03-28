using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models.Mfa
{
    public class MfaRecoveryCodeResponse : TokenBase
    {
        /// <summary>
        /// The duration in seconds that the access token is valid.
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Recovery code to be stored securely for future use.
        /// </summary>
        [JsonProperty("recovery_code")]
        public string RecoveryCode { get; set; }
    }
}