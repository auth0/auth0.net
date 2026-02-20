using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateActionModuleVersionResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique ID for this version.
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The ID of the parent module.
    /// </summary>
    [Optional]
    [JsonPropertyName("module_id")]
    public string? ModuleId { get; set; }

    /// <summary>
    /// The sequential version number.
    /// </summary>
    [Optional]
    [JsonPropertyName("version_number")]
    public int? VersionNumber { get; set; }

    /// <summary>
    /// The exact source code that was published with this version.
    /// </summary>
    [Optional]
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    /// Secrets available to this version (name and updated_at only, values never returned).
    /// </summary>
    [Optional]
    [JsonPropertyName("secrets")]
    public IEnumerable<ActionModuleSecret>? Secrets { get; set; }

    /// <summary>
    /// Dependencies locked to this version.
    /// </summary>
    [Optional]
    [JsonPropertyName("dependencies")]
    public IEnumerable<ActionModuleDependency>? Dependencies { get; set; }

    /// <summary>
    /// The timestamp when this version was created.
    /// </summary>
    [Optional]
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

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
