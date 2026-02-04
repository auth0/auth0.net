using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateConnectionProfileResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

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
