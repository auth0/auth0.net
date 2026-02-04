using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Connection Profile Strategy Override
/// </summary>
[Serializable]
public record ConnectionProfileStrategyOverride : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("enabled_features")]
    public IEnumerable<EnabledFeaturesEnum>? EnabledFeatures { get; set; }

    [Optional]
    [JsonPropertyName("connection_config")]
    public ConnectionProfileStrategyOverridesConnectionConfig? ConnectionConfig { get; set; }

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
