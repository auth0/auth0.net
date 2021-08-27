using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Actions
{
    public class Trigger
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("runtimes")]
        public IList<string> Runtimes { get; set; }

        [JsonProperty("default_runtime")]
        public string DefaultRuntime { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}