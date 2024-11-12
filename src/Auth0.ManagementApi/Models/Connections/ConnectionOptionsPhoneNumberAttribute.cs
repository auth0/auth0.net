using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Connections
{
    /// <summary>
    /// Configuration for the phone number attribute for users.
    /// </summary>
    public class ConnectionOptionsPhoneNumberAttribute : ConnectionOptionsAttributeBase
    {
        /// <summary>
        /// Phone Number Connection Attribute sign-up
        /// </summary>
        [JsonProperty("signup")]
        public ConnectionOptionsPhoneNumberSignup Signup { get; set; }
    }
}