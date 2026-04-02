using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Branding.Phone;

[Serializable]
public record CreatePhoneProviderSendTestRequestContent
{
    /// <summary>
    /// The recipient phone number to receive a given notification.
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
