using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Forms
{
    public class Style
    {
        [JsonProperty("css")]
        public string Css { get; set; }
    }
}