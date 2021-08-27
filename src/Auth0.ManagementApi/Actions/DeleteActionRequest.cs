using Newtonsoft.Json;

namespace Auth0.ManagementApi.Actions
{
    public class DeleteActionRequest
    {
        [JsonProperty("force")]
        public bool? Force { get; set; }
    }
}