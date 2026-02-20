using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Guardian.Factors;

[Serializable]
public record SetGuardianFactorsProviderPushNotificationFcmv1RequestContent
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
