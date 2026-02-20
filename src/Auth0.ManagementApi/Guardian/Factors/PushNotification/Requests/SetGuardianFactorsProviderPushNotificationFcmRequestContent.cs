using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Guardian.Factors;

[Serializable]
public record SetGuardianFactorsProviderPushNotificationFcmRequestContent
{
    [Nullable, Optional]
    [JsonPropertyName("server_key")]
    public Optional<string?> ServerKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
