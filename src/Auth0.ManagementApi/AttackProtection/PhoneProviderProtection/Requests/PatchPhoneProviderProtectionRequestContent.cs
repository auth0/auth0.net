using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.AttackProtection;

[Serializable]
public record PatchPhoneProviderProtectionRequestContent
{
    [JsonPropertyName("type")]
    public required PhoneProviderProtectionBackoffStrategyEnum Type { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
