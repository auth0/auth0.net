using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

public class DuoConfiguration
{
    [JsonProperty("ikey")]
    public string Ikey { get; set; }
        
    [JsonProperty("skey")]
    public string Skey { get; set; }
        
    [JsonProperty("host")]
    public string Host { get; set; }
}