using Auth0.ManagementApi.Clients;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Base class for email templates
    /// </summary>
    public abstract class EmailTemplateBase
    {
        /// <summary>
        /// The body of the template.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// The sender of the email.
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// The URL to redirect the user to after a successful action.
        /// </summary>
        [JsonProperty("resultUrl")]
        public string ResultUrl { get; set; }

        /// <summary>
        /// The subject of the email.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// The lifetime in seconds that the link within the email will be valid for.
        /// </summary>
        [JsonProperty("urlLifetimeInSeconds")]
        public int? UrlLifetimeInSeconds { get; set; }
    }
}