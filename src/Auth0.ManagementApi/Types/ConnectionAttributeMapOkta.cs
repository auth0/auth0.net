using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Mapping of claims received from the identity provider (IdP)
/// </summary>
[Serializable]
public record ConnectionAttributeMapOkta : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("attributes")]
    public Dictionary<string, object?>? Attributes { get; set; }

    [Optional]
    [JsonPropertyName("mapping_mode")]
    public ConnectionMappingModeEnumOkta? MappingMode { get; set; }

    [Optional]
    [JsonPropertyName("userinfo_scope")]
    public string? UserinfoScope { get; set; }

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
