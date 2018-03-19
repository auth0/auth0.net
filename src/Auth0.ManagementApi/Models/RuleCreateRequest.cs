using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class RuleCreateRequest : RuleBase
    {

        /// <summary>
        /// Gets or sets the execution stage of the rule.
        /// </summary>
        [JsonProperty("stage")]
        public string Stage { get; set; }

    }

}