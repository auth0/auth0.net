using Newtonsoft.Json;

namespace Auth0.Core
{
    public class DeviceCredential : DeviceCredentialBase
    {
        /// <summary>
        /// Gets or sets the device's identifier.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}