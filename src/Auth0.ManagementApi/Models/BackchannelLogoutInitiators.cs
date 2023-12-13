using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class BackchannelLogoutInitiators
    {
        /// <summary>
        /// The mode property determines the configuration method for enabling initiators.
        /// </summary>
        [JsonProperty("mode")]
        public LogoutInitiatorModes Mode { get; set; }

        /// <summary>
        /// The Selected Initiators are the logout initiators to be enabled for the client.
        /// </summary>
        [JsonProperty("selected_initiators")]
        public LogoutInitiators[] SelectedInitiators { get; set; }
    }
}
