using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateConnectionProfileRequestContent
{
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
