using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Forms;

public class AfterSubmit
{
    [JsonProperty("flow_id")]
    public string FlowId { get; set; }
}