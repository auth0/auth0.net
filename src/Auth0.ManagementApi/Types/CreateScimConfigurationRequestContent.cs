using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateScimConfigurationRequestContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// User ID attribute for generating unique user ids
    /// </summary>
    [Optional]
    [JsonPropertyName("user_id_attribute")]
    public string? UserIdAttribute { get; set; }

    /// <summary>
    /// The mapping between auth0 and SCIM
    /// </summary>
    [Optional]
    [JsonPropertyName("mapping")]
    public IEnumerable<ScimMappingItem>? Mapping { get; set; }

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
