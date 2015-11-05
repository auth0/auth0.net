using Newtonsoft.Json;

namespace Auth0.Core.Models
{
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