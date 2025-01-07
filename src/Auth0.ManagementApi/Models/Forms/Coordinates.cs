using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Forms
{
    public class Coordinates
    {
        [JsonProperty("x")]
        public int X { get; set; }
        
        [JsonProperty("y")]
        public int Y { get; set; }
    }
}