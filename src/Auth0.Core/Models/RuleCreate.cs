using Newtonsoft.Json;

namespace Auth0.Core.Models
{
    public class RuleCreate : RuleBase
    {
        /// <summary>
        /// Gets or sets the execution stage of the rule.
        /// </summary>
        [JsonProperty("stage")]
        public string Stage { get; set; }
    }
}