using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Strategy-specific overrides for this attribute
/// </summary>
[Serializable]
public record ConnectionProfileStrategyOverrides : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("pingfederate")]
    public ConnectionProfileStrategyOverride? Pingfederate { get; set; }

    [Optional]
    [JsonPropertyName("ad")]
    public ConnectionProfileStrategyOverride? Ad { get; set; }

    [Optional]
    [JsonPropertyName("adfs")]
    public ConnectionProfileStrategyOverride? Adfs { get; set; }

    [Optional]
    [JsonPropertyName("waad")]
    public ConnectionProfileStrategyOverride? Waad { get; set; }

    [Optional]
    [JsonPropertyName("google-apps")]
    public ConnectionProfileStrategyOverride? GoogleApps { get; set; }

    [Optional]
    [JsonPropertyName("okta")]
    public ConnectionProfileStrategyOverride? Okta { get; set; }

    [Optional]
    [JsonPropertyName("oidc")]
    public ConnectionProfileStrategyOverride? Oidc { get; set; }

    [Optional]
    [JsonPropertyName("samlp")]
    public ConnectionProfileStrategyOverride? Samlp { get; set; }

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
