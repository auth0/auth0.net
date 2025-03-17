using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.SelfServiceProfiles
{
    /// <summary>
    /// If provided, this will create a new connection for the SSO flow with the given configuration.
    /// </summary>
    public class SelfServiceSsoConnectionConfig
    {
        /// <summary>
        /// Name of the connection that will be created as part of the SSO flow.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Display name of the connection that will be created as part of the SSO flow.
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Flag indicating if this is a domain connection
        /// </summary>
        [JsonProperty("is_domain_connection")]
        public bool IsDomainConnection { get; set; }

        /// <summary>
        /// Flag indicating if the connection should be displayed as a button. 
        /// </summary>
        [JsonProperty("show_as_button")]
        public bool ShowAsButton { get; set; }
    }
}