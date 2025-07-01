using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

public class BrandingPhoneTestNotificationRequest
{
    /// <summary>
    /// The recipient phone number to receive a given notification.
    /// </summary>
    [JsonProperty("to")]
    public string To { get; set; }
        
    /// <summary>
    /// The delivery method for the notification
    /// </summary>
    [JsonProperty("delivery_method")]
    public string DeliveryMethod { get; set; }
}