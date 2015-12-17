using Newtonsoft.Json;

namespace Auth0.Core
{
    // TODO: There are a limited number of email providers. Should we not try something more specific which will prevent the user 
    // from making mistakes in configuring this? All fields are not required for all providers...

    /// <summary>
    /// Credentials for an email provider.
    /// </summary>
    public class EmailProviderCredentials
    {
        /// <summary>
        /// Gets or sets the API User.
        /// </summary>
        /// <remarks>
        /// Applicable only to the SendGrid provider.
        /// </remarks>
        [JsonProperty("api_user")]
        public string ApiUser { get; set; }

        /// <summary>
        /// Gets or sets the API Key.
        /// </summary>
        /// <remarks>
        /// Applicable only to the SendGrid  and Mandrill providers.
        /// </remarks>
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the Access Key ID.
        /// </summary>
        /// <remarks>
        /// Applicable only to the AWS provider.
        /// </remarks>
        [JsonProperty("accessKeyId")]
        public string AccessKeyId { get; set; }

        /// <summary>
        /// Gets or sets the Secret Access Key.
        /// </summary>
        /// <remarks>
        /// Applicable only to the AWS provider.
        /// </remarks>
        [JsonProperty("secretAccessKey")]
        public string SecretAccessKey { get; set; }

        /// <summary>
        /// Gets or sets the default AWS region.
        /// </summary>
        /// <remarks>
        /// Applicable only to the AWS provider.
        /// </remarks>
        [JsonProperty("region")]
        public string Region { get; set; }
    }
}