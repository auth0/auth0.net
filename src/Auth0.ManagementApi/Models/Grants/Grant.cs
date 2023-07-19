using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Grants
{
    public class Grant
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("clientID")]
        public string ClientId { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("audience")]
        public string Audience { get; set; }
        [JsonProperty("scope")]
        public IList<string> Scope { get; set; }

    }
}
