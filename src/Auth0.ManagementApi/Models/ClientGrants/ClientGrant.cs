using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents a Client Grant
    /// </summary>
    public class ClientGrant : ClientGrantBase
    {
        /// <summary>
        /// Gets or sets the identifier for a Client Grant.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}