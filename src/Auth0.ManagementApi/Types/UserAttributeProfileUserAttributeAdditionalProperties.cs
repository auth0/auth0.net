using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UserAttributeProfileUserAttributeAdditionalProperties : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Description of this attribute
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// Display label for this attribute
    /// </summary>
    [JsonPropertyName("label")]
    public required string Label { get; set; }

    /// <summary>
    /// Whether this attribute is required in the profile
    /// </summary>
    [JsonPropertyName("profile_required")]
    public required bool ProfileRequired { get; set; }

    /// <summary>
    /// Auth0 mapping for this attribute
    /// </summary>
    [JsonPropertyName("auth0_mapping")]
    public required string Auth0Mapping { get; set; }

    [Optional]
    [JsonPropertyName("oidc_mapping")]
    public UserAttributeProfileOidcMapping? OidcMapping { get; set; }

    [Optional]
    [JsonPropertyName("saml_mapping")]
    public IEnumerable<string>? SamlMapping { get; set; }

    /// <summary>
    /// SCIM mapping for this attribute
    /// </summary>
    [Optional]
    [JsonPropertyName("scim_mapping")]
    public string? ScimMapping { get; set; }

    [Optional]
    [JsonPropertyName("strategy_overrides")]
    public UserAttributeProfileStrategyOverrides? StrategyOverrides { get; set; }

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
