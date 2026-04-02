using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UserAttributeProfileStrategyOverridesUserIdMapping : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("oidc_mapping")]
    public UserAttributeProfileUserIdOidcStrategyOverrideMapping? OidcMapping { get; set; }

    [Optional]
    [JsonPropertyName("saml_mapping")]
    public IEnumerable<string>? SamlMapping { get; set; }

    /// <summary>
    /// SCIM mapping override for this strategy
    /// </summary>
    [Optional]
    [JsonPropertyName("scim_mapping")]
    public string? ScimMapping { get; set; }

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
