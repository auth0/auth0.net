using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Base class for rules.
    /// </summary>
    public abstract class RuleBase
    {
        /// <summary>
        /// Gets or sets the name of the rule.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets whether the rule is enabled.        
        /// </summary>
        /// <remarks>
        /// True if the connection is enabled, false otherwise.
        /// </remarks>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets or sets the code to be executed when the rule runs.
        /// </summary>
        [JsonProperty("script")]
        public string Script { get; set; }

        /// <summary>
        /// Gets or sets the order of the rule in relation to other rules. A rule with a lower order than another rule executes first.
        /// </summary>
        [JsonProperty("order")]
        public int? Order { get; set; }
    }
}