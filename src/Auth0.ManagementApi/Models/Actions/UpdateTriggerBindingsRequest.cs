using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// Request configuration to update the actions that are bound (i.e. attached) to a trigger.
    /// </summary>
    public class UpdateTriggerBindingsRequest
    {
        /// <summary>
        /// The actions that will be bound to this trigger. The order in which they are included will be the order in which they are executed.
        /// </summary>
        [JsonProperty("bindings")]
        public IList<UpdateTriggerBindingEntry> Bindings { get; set; }
    }
}