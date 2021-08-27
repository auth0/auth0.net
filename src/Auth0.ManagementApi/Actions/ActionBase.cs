using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Actions
{
    public class ActionBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("dependencies")]
        public IList<ActionDependency> Dependencies { get; set; }

        [JsonProperty("runtime")]
        public string Runtime { get; set; }

        [JsonProperty("secrets")]
        public IList<ActionSecret> Secrets { get; set; }
    }
}