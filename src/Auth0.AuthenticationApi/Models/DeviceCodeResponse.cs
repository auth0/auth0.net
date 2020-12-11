using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents the response from a Device Authorization request.
    /// </summary>
    public class DeviceCodeResponse
    {
        /// <summary>
        /// The unique code for the device. When the user goes to the <see cref="VerificationUri"/> in their browser-based device, this code will be bound to their session.
        /// </summary>
        [JsonProperty("device_code")]
        public string DeviceCode { get; set; }

        /// <summary>
        /// The code that should be input at the <see cref="VerificationUri"/> to authorize the device.
        /// </summary>
        [JsonProperty("user_code")]
        public string UserCode { get; set; }

        /// <summary>
        /// The URL the user should visit to authorize the device.
        /// </summary>
        [JsonProperty("verification_uri")]
        public string VerificationUri { get; set; }

        /// <summary>
        /// The lifetime (in seconds) of the <see cref="DeviceCode"/> and <see cref="UserCode"/>.
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// The interval (in seconds) at which the app should poll the token URL to request a token.
        /// </summary>
        [JsonProperty("interval")]
        public int Interval { get; set; }

        /// <summary>
        ///  The complete URL the user should visit to authorize the device. This allows embedding the <see cref="UserCode"/> in the URL.
        /// </summary>
        [JsonProperty("verification_uri_complete")]
        public string VerificationUriComplete { get; set; }
    }
}