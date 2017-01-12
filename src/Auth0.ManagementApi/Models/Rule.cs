using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents a rule. A rule is arbitrary JavaScript code that can be used to extend Auth0's default behavior when authenticating a user.
    /// </summary>
    public class Rule : RuleBase
    {
        /// <summary>
        /// Gets or sets the identifier for the rule.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the execution stage of the rule.
        /// </summary>
        [JsonProperty("stage")]
        public string Stage { get; set; }
    }

}