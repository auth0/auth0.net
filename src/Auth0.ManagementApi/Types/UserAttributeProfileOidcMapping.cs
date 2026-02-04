using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// OIDC mapping for this attribute
/// </summary>
[Serializable]
public record UserAttributeProfileOidcMapping : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// OIDC mapping field
    /// </summary>
    [JsonPropertyName("mapping")]
    public required string Mapping { get; set; }

    /// <summary>
    /// Display name for the OIDC mapping
    /// </summary>
    [Optional]
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

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
