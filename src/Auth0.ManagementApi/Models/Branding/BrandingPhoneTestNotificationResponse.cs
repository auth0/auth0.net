using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

public class BrandingPhoneTestNotificationResponse
{
    /// <summary>
    /// The status code of the operation.
    /// </summary>
    [JsonProperty("code")]
    public float Code { get; set; }
        
    /// <summary>
    /// The description of the operation status.
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; }
}