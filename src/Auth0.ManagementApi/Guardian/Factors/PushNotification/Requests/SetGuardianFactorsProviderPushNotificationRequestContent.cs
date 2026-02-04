using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Guardian.Factors;

[Serializable]
public record SetGuardianFactorsProviderPushNotificationRequestContent
{
    [JsonPropertyName("provider")]
    public required GuardianFactorsProviderPushNotificationProviderDataEnum Provider { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
