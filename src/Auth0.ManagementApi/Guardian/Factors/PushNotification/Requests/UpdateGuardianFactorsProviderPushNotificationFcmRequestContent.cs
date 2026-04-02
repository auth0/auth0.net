using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Guardian.Factors;

[Serializable]
public record UpdateGuardianFactorsProviderPushNotificationFcmRequestContent
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
