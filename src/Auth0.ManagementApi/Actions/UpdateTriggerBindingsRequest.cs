using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Actions
{
    public class UpdateTriggerBindingsRequest
    {
        [JsonProperty("bindings")]
        public IList<UpdateTriggerBindingEntry> Bindings { get; set; }
    }
}