using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class PushNotificationApnsConfigurationUpdateRequestBase
    {
        [JsonProperty("bundle_id")] 
        public string BundleId { get; set; }

        [JsonProperty("sandbox")] 
        public bool? Sandbox { get; set; }
        
        [JsonProperty("p12")] 
        public string P12 { get; set; }
    }

    public class
        PushNotificationApnsConfigurationPatchUpdateRequest : PushNotificationApnsConfigurationUpdateRequestBase
    {
        
    }
    
    public class
        PushNotificationApnsConfigurationPutUpdateRequest : PushNotificationApnsConfigurationUpdateRequestBase
    {
        
    }
}