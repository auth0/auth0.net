using Newtonsoft.Json;

namespace Auth0.ManagementApi.Actions
{
    public class UpdateTriggerBindingEntry
    {
        public class BindingRef
        {
            [JsonProperty("type")]
            public string Type { get; set; }
            [JsonProperty("value")]
            public string Value { get; set; }
        }

        [JsonProperty("ref")]
        public BindingRef Ref { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
    }
}