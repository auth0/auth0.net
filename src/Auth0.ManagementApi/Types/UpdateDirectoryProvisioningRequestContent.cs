using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateDirectoryProvisioningRequestContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The mapping between Auth0 and IDP user attributes
    /// </summary>
    [Optional]
    [JsonPropertyName("mapping")]
    public IEnumerable<DirectoryProvisioningMappingItem>? Mapping { get; set; }

    /// <summary>
    /// Whether periodic automatic synchronization is enabled
    /// </summary>
    [Optional]
    [JsonPropertyName("synchronize_automatically")]
    public bool? SynchronizeAutomatically { get; set; }

    [Optional]
    [JsonPropertyName("synchronize_groups")]
    public string? SynchronizeGroups { get; set; }

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
