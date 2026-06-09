using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Security headers configuration for tenant responses.
/// </summary>
[Serializable]
public record TenantSettingsNullableSecurityHeaders : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Nullable, Optional]
    [JsonPropertyName("content_security_policy")]
    public Optional<ContentSecurityPolicyConfig?> ContentSecurityPolicy { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("x_xss_protection")]
    public Optional<XssProtectionConfig?> XXssProtection { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
