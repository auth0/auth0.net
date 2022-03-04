using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents a rules config variable. 
    /// A rules-config is a variable defined by its key that carries an encrypted value, accessible only from within the rules.
    /// </summary>
    public class RulesConfig
    {
        /// <summary>
        /// Gets or sets the key for the rules config variable.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the body for the rules config variable.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
