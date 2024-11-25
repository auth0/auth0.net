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
    }
}