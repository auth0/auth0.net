using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

public class PushNotificationApnsConfiguration
{
    [JsonProperty("bundle_id")]
    public string BundleId { get; set; }
        
    [JsonProperty("sandbox")]
    public bool? Sandbox { get; set; }
        
    [JsonProperty("enabled")]
    public bool? Enabled { get; set; }
}
    
public class PushNotificationApnsConfigurationUpdateResponse
{
    [JsonProperty("bundle_id")]
    public string BundleId { get; set; }
        
    [JsonProperty("sandbox")]
    public bool? Sandbox { get; set; }
}