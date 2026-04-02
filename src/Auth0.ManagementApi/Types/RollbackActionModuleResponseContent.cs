using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record RollbackActionModuleResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique ID of the module.
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The name of the module.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The source code from the module's draft version.
    /// </summary>
    [Optional]
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    /// The npm dependencies from the module's draft version.
    /// </summary>
    [Optional]
    [JsonPropertyName("dependencies")]
    public IEnumerable<ActionModuleDependency>? Dependencies { get; set; }

    /// <summary>
    /// The secrets from the module's draft version (names and timestamps only, values never returned).
    /// </summary>
    [Optional]
    [JsonPropertyName("secrets")]
    public IEnumerable<ActionModuleSecret>? Secrets { get; set; }

    /// <summary>
    /// The number of deployed actions using this module.
    /// </summary>
    [Optional]
    [JsonPropertyName("actions_using_module_total")]
    public int? ActionsUsingModuleTotal { get; set; }

    /// <summary>
    /// Whether all draft changes have been published as a version.
    /// </summary>
    [Optional]
    [JsonPropertyName("all_changes_published")]
    public bool? AllChangesPublished { get; set; }

    /// <summary>
    /// The version number of the latest published version. Omitted if no versions have been published.
    /// </summary>
    [Optional]
    [JsonPropertyName("latest_version_number")]
    public int? LatestVersionNumber { get; set; }

    /// <summary>
    /// Timestamp when the module was created.
    /// </summary>
    [Optional]
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Timestamp when the module was last updated.
    /// </summary>
    [Optional]
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Optional]
    [JsonPropertyName("latest_version")]
    public ActionModuleVersionReference? LatestVersion { get; set; }

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
