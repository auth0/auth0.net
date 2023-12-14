using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    public class BackchannelLogoutInitiators
    {
        /// <summary>
        /// The mode property determines the configuration method for enabling initiators.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("mode")]
        public LogoutInitiatorModes Mode { get; set; }

        /// <summary>
        /// The Selected Initiators are the logout initiators to be enabled for the client.
        /// </summary>
        [JsonProperty("selected_initiators", ItemConverterType = typeof(StringEnumConverter))]
        public LogoutInitiators[] SelectedInitiators { get; set; }
    }
}
