using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Strategy-specific overrides for this attribute
/// </summary>
[Serializable]
public record UserAttributeProfileStrategyOverrides : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("pingfederate")]
    public UserAttributeProfileStrategyOverridesMapping? Pingfederate { get; set; }

    [Optional]
    [JsonPropertyName("ad")]
    public UserAttributeProfileStrategyOverridesMapping? Ad { get; set; }

    [Optional]
    [JsonPropertyName("adfs")]
    public UserAttributeProfileStrategyOverridesMapping? Adfs { get; set; }

    [Optional]
    [JsonPropertyName("waad")]
    public UserAttributeProfileStrategyOverridesMapping? Waad { get; set; }

    [Optional]
    [JsonPropertyName("google-apps")]
    public UserAttributeProfileStrategyOverridesMapping? GoogleApps { get; set; }

    [Optional]
    [JsonPropertyName("okta")]
    public UserAttributeProfileStrategyOverridesMapping? Okta { get; set; }

    [Optional]
    [JsonPropertyName("oidc")]
    public UserAttributeProfileStrategyOverridesMapping? Oidc { get; set; }

    [Optional]
    [JsonPropertyName("samlp")]
    public UserAttributeProfileStrategyOverridesMapping? Samlp { get; set; }

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
