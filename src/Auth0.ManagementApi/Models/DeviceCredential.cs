using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents device credentials returned from the API.
    /// </summary>
    public class DeviceCredential : DeviceCredentialBase
    {
        /// <summary>
        /// Gets or sets the device's identifier.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}