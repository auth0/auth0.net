using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// Request configuration for creating an action.
    /// </summary>
    public class CreateActionRequest : ActionBase
    {
        /// <summary>
        /// The list of triggers that this action supports. At this time, an action can only target a single trigger at a time.
        /// </summary>
        [JsonProperty("supported_triggers")]
        public IList<ActionSupportedTrigger> SupportedTriggers { get; set; }
    }
}