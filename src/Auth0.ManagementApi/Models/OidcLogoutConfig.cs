using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class OidcLogoutConfig
    {
        /// <summary>
        /// The supported backchannel logout URLs for the client.
        /// </summary>
        [JsonProperty("backchannel_logout_urls")]
        public string[] BackchannelLogoutUrls { get; set; }

        /// <summary>
        /// The OIDC Back-Channel Logout Initiators for the client.
        /// </summary>
        [JsonProperty("backchannel_logout_initiators")]
        public BackchannelLogoutInitiators BackchannelLogoutInitiators { get; set; }
    }
}
