using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Strategy-specific overrides for user ID
/// </summary>
[Serializable]
public record UserAttributeProfileStrategyOverridesUserId : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("pingfederate")]
    public UserAttributeProfileStrategyOverridesUserIdMapping? Pingfederate { get; set; }

    [Optional]
    [JsonPropertyName("ad")]
    public UserAttributeProfileStrategyOverridesUserIdMapping? Ad { get; set; }

    [Optional]
    [JsonPropertyName("adfs")]
    public UserAttributeProfileStrategyOverridesUserIdMapping? Adfs { get; set; }

    [Optional]
    [JsonPropertyName("waad")]
    public UserAttributeProfileStrategyOverridesUserIdMapping? Waad { get; set; }

    [Optional]
    [JsonPropertyName("google-apps")]
    public UserAttributeProfileStrategyOverridesUserIdMapping? GoogleApps { get; set; }

    [Optional]
    [JsonPropertyName("okta")]
    public UserAttributeProfileStrategyOverridesUserIdMapping? Okta { get; set; }

    [Optional]
    [JsonPropertyName("oidc")]
    public UserAttributeProfileStrategyOverridesUserIdMapping? Oidc { get; set; }

    [Optional]
    [JsonPropertyName("samlp")]
    public UserAttributeProfileStrategyOverridesUserIdMapping? Samlp { get; set; }

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
