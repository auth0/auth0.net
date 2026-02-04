using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UserAttributeProfileStrategyOverridesMapping : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("oidc_mapping")]
    public UserAttributeProfileOidcMapping? OidcMapping { get; set; }

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
