using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Reference to a module and its version used by an action.
/// </summary>
[Serializable]
public record ActionModuleReference : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique ID of the module.
    /// </summary>
    [Optional]
    [JsonPropertyName("module_id")]
    public string? ModuleId { get; set; }

    /// <summary>
    /// The name of the module.
    /// </summary>
    [Optional]
    [JsonPropertyName("module_name")]
    public string? ModuleName { get; set; }

    /// <summary>
    /// The ID of the specific module version.
    /// </summary>
    [Optional]
    [JsonPropertyName("module_version_id")]
    public string? ModuleVersionId { get; set; }

    /// <summary>
    /// The version number of the module.
    /// </summary>
    [Optional]
    [JsonPropertyName("module_version_number")]
    public int? ModuleVersionNumber { get; set; }

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
