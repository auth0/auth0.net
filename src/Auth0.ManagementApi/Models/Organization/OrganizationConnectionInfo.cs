using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Information on the enabled connection for an Organization
    /// </summary>
    public class OrganizationConnectionInfo
    {
        /// <summary>
        /// The name of the enabled connection.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The strategy of the enabled connection.
        /// </summary>
        [JsonProperty("strategy")]
        public string Strategy { get; set; }
    }
}