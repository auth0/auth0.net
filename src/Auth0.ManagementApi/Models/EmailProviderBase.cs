using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Base class for email provider.
    /// </summary>
    public abstract class EmailProviderBase
    {
        /// <summary>
        /// Gets or sets the default from address
        /// </summary>
        [JsonProperty("default_from_address")]
        public string DefaultFromAddress { get; set; }

        /// <summary>
        /// Gets or sets the name of the provider.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets whether using your own email provider is enabled.
        /// </summary>
        [JsonProperty("enabled")]
        public bool? IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the name of the email provider.
        /// </summary>
        [JsonProperty("credentials")]
        public EmailProviderCredentials Credentials { get; set; }

        /// <summary>
        /// Gets or sets the settings of the email provider.
        /// </summary>
        [JsonProperty("settings")]
        public dynamic Settings { get; set; }
    }
}