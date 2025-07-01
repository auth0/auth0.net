using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Forms;

public class Start
{
    [JsonProperty("hidden_fields")]
    public HiddenFields[] HiddenFields { get; set; }
        
    [JsonProperty("next_node")]
    public string NextNode { get; set; }
        
    [JsonProperty("coordinates")]
    public Coordinates Coordinates { get; set; }
}