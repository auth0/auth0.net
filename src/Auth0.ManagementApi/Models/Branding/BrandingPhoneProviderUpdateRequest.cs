using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

public class BrandingPhoneProviderUpdateRequest : BrandingPhoneProviderBase
{
    [JsonProperty("credentials")]
    public BrandingCredential Credentials { get; set; }
}