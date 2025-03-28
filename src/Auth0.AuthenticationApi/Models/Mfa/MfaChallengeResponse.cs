using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models.Mfa
{
    public class MfaChallengeResponse
    {
        /// <summary>
        /// Type of challenge issued.
        /// </summary>
        [JsonProperty("challenge_type")]
        public string ChallengeType { get; set; }

        /// <summary>
        /// Code for out-of-band challenge (only if applicable).
        /// </summary>
        [JsonProperty("oob_code")]
        public string OobCode { get; set; }

        /// <summary>
        /// Method used for binding (only if applicable).
        /// </summary>
        [JsonProperty("binding_method")]
        public string BindingMethod { get; set; }
    }
}