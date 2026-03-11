using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// User ID mapping configuration
/// </summary>
[Serializable]
public record UserAttributeProfileUserId : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("oidc_mapping")]
    public UserAttributeProfileUserIdOidcMappingEnum? OidcMapping { get; set; }

    [Optional]
    [JsonPropertyName("saml_mapping")]
    public IEnumerable<string>? SamlMapping { get; set; }

    /// <summary>
    /// SCIM mapping for user ID
    /// </summary>
    [Optional]
    [JsonPropertyName("scim_mapping")]
    public string? ScimMapping { get; set; }

    [Optional]
    [JsonPropertyName("strategy_overrides")]
    public UserAttributeProfileStrategyOverridesUserId? StrategyOverrides { get; set; }

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
