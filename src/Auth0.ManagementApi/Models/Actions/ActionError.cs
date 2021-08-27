using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    public class ActionError
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}