using Newtonsoft.Json;

namespace Auth0.Core
{
    /// <summary>
    /// Represents credentials for a device.
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