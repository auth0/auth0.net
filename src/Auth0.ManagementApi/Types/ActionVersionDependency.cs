using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Dependency is an npm module. These values are used to produce an immutable artifact, which manifests as a layer_id.
/// </summary>
[Serializable]
public record ActionVersionDependency : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// name is the name of the npm module, e.g. lodash
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// description is the version of the npm module, e.g. 4.17.1
    /// </summary>
    [Optional]
    [JsonPropertyName("version")]
    public string? Version { get; set; }

    /// <summary>
    /// registry_url is an optional value used primarily for private npm registries.
    /// </summary>
    [Optional]
    [JsonPropertyName("registry_url")]
    public string? RegistryUrl { get; set; }

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
