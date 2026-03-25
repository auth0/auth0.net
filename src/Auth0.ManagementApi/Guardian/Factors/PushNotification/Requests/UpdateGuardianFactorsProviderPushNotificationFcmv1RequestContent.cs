using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Guardian.Factors;

[Serializable]
public record UpdateGuardianFactorsProviderPushNotificationFcmv1RequestContent
{
    [Nullable, Optional]
    [JsonPropertyName("server_credentials")]
    public Optional<string?> ServerCredentials { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
