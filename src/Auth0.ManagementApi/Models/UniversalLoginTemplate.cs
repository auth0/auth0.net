using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class UniversalLoginTemplate
    {
        /// <summary>
        /// The custom page template for the new universal login experience.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}