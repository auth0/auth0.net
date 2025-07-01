using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

public class FcmV1ConfigurationUpdateRequestBase
{
    [JsonProperty("server_credentials")]
    public string ServerCredentials { get; set; }
}
    
public class FcmV1ConfigurationPatchUpdateRequest : FcmV1ConfigurationUpdateRequestBase
{
}
    
public class FcmV1ConfigurationPutUpdateRequest : FcmV1ConfigurationUpdateRequestBase
{
}