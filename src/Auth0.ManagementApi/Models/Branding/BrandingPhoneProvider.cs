using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

public class BrandingPhoneProvider : BrandingPhoneProviderBase
{
    [JsonProperty("id")] 
    public string Id { get; set; }
}