using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Branding.Phone;

[Serializable]
public record CreatePhoneTemplateTestNotificationRequestContent
{
    /// <summary>
    /// Destination of the testing phone notification
    /// </summary>
    [JsonPropertyName("to")]
    public required string To { get; set; }

    [Optional]
    [JsonPropertyName("delivery_method")]
    public PhoneProviderDeliveryMethodEnum? DeliveryMethod { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
