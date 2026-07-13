using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Mapping of claims received from the identity provider (IdP)
/// </summary>
[Serializable]
public record EventStreamCloudEventConnectionDeletedObject1OptionsAttributeMap : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("attributes")]
    public Dictionary<string, object?>? Attributes { get; set; }

    /// <summary>
    /// Scopes to send to the IdP's Userinfo endpoint
    /// </summary>
    [Optional]
    [JsonPropertyName("userinfo_scope")]
    public string? UserinfoScope { get; set; }

    [Optional]
    [JsonPropertyName("mapping_mode")]
    public EventStreamCloudEventConnectionDeletedObject1OptionsAttributeMapMappingModeEnum? MappingMode { get; set; }

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
