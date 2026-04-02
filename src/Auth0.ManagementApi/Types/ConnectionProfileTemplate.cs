using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The structure of the template, which can be used as the payload for creating or updating a Connection Profile.
/// </summary>
[Serializable]
public record ConnectionProfileTemplate : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Optional]
    [JsonPropertyName("organization")]
    public ConnectionProfileOrganization? Organization { get; set; }

    [Optional]
    [JsonPropertyName("connection_name_prefix_template")]
    public string? ConnectionNamePrefixTemplate { get; set; }

    [Optional]
    [JsonPropertyName("enabled_features")]
    public IEnumerable<EnabledFeaturesEnum>? EnabledFeatures { get; set; }

    [Optional]
    [JsonPropertyName("connection_config")]
    public ConnectionProfileConfig? ConnectionConfig { get; set; }

    [Optional]
    [JsonPropertyName("strategy_overrides")]
    public ConnectionProfileStrategyOverrides? StrategyOverrides { get; set; }

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
