using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class FcmConfigurationUpdateRequestBase
    {
        [JsonProperty("server_key")]
        public string ServerKey { get; set; }
    }
    
    public class FcmConfigurationPatchUpdateRequest : FcmConfigurationUpdateRequestBase
    {
    }
    
    public class FcmConfigurationPutUpdateRequest : FcmConfigurationUpdateRequestBase
    {
    }
}