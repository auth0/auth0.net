using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
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

        /// <summary>
        /// Gets or sets the host name or IP address of the SMTP server
        /// </summary>
        [JsonProperty("smtp_host")]
        public string SmtpHost { get; set; }

        /// <summary>
        /// Gets or sets the port used by the SMTP server
        /// </summary>
        /// <remarks>
        /// Common ports include 25, 465, and 587. Please avoid using port 25 if you can, since many providers have limitations on this port.
        /// </remarks>
        [JsonProperty("smtp_port")]
        public int? SmtpPort { get; set; }

        /// <summary>
        /// Gets or sets the username for the SMTP server
        /// </summary>
        [JsonProperty("smtp_user")]
        public string SmtpUsername { get; set; }

        /// <summary>
        /// Gets or sets the password for the SMTP server
        /// </summary>
        [JsonProperty("smtp_pass")]
        public string SmtpPassword { get; set; }
    }
}