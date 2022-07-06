using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Specifies the properies for updating an existing connection.
    /// </summary>
    public class ConnectionUpdateRequest : ConnectionBase
    {
        /// <summary>
        /// The text used on the login button.
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
    }
}