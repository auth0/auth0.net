using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Base class for device credentials.
    /// </summary>
    public abstract class DeviceCredentialBase
    {
        /// <summary>
        /// Gets or sets the device's name.
        /// </summary>
        /// <remarks>
        /// This is a value that must be easily recognized by the device's owner.
        /// </remarks>
        [JsonProperty("device_name")]
        public string DeviceName { get; set; }

        /// <summary>
        /// Gets or sets a unique identifier for the device.
        /// </summary>
        [JsonProperty("device_id")]
        public string DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the type of the credential.
        /// </summary>
        /// <remarks>
        /// This should be either "public_key" or "refresh_token".
        /// </remarks>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the ID of the client for which the credential will be created.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
    }
}