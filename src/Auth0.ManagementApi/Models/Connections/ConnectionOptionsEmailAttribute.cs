using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Connections
{
    /// <summary>
    /// Configuration for the email attribute for users.
    /// </summary>
    public class ConnectionOptionsEmailAttribute : ConnectionOptionsAttributeBase
    {
        /// <summary>
        /// Email Connection Attribute sign-up
        /// </summary>
        [JsonProperty("signup")]
        public ConnectionOptionsEmailSignup Signup { get; set; }
    }
}