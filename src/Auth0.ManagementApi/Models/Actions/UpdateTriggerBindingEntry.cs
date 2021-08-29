using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    public class UpdateTriggerBindingEntry
    {
        public class BindingRef
        {
            /// <summary>
            ///  How the action is being referred to: `action_id` or `action_name`.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// The id or name of an action that is being bound to a trigger.
            /// </summary>
            [JsonProperty("value")]
            public string Value { get; set; }
        }

        /// <summary>
        /// A reference to an action. An action can be referred to by ID or by Name.
        /// </summary>
        [JsonProperty("ref")]
        public BindingRef Ref { get; set; }

        /// <summary>
        /// The name of the binding.
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
    }
}