using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Actions
{
    public class CreateActionRequest: ActionBase
    {
        [JsonProperty("supported_triggers")]
        public IList<ActionSupportedTrigger> SupportedTriggers { get; set; }
    }
}