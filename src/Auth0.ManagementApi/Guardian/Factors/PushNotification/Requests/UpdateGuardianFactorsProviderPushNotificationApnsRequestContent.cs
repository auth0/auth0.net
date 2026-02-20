using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Guardian.Factors;

[Serializable]
public record UpdateGuardianFactorsProviderPushNotificationApnsRequestContent
{
    [Optional]
    [JsonPropertyName("sandbox")]
    public bool? Sandbox { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("bundle_id")]
    public Optional<string?> BundleId { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("p12")]
    public Optional<string?> P12 { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
