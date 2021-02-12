using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Request for updating a universal login template
    /// </summary>
    public class UniversalLoginTemplateUpdateRequest
    {
        /// <summary>
        /// Gets or sets the custom page template for the New Universal Login Experience
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}