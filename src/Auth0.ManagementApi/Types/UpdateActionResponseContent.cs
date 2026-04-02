using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateActionResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique ID of the action.
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The name of an action.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The list of triggers that this action supports. At this time, an action can only target a single trigger at a time.
    /// </summary>
    [Optional]
    [JsonPropertyName("supported_triggers")]
    public IEnumerable<ActionTrigger>? SupportedTriggers { get; set; }

    /// <summary>
    /// True if all of an Action's contents have been deployed.
    /// </summary>
    [Optional]
    [JsonPropertyName("all_changes_deployed")]
    public bool? AllChangesDeployed { get; set; }

    /// <summary>
    /// The time when this action was created.
    /// </summary>
    [Optional]
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The time when this action was updated.
    /// </summary>
    [Optional]
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// The source code of the action.
    /// </summary>
    [Optional]
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    /// The list of third party npm modules, and their versions, that this action depends on.
    /// </summary>
    [Optional]
    [JsonPropertyName("dependencies")]
    public IEnumerable<ActionVersionDependency>? Dependencies { get; set; }

    /// <summary>
    /// The Node runtime. For example: `node22`, defaults to `node22`
    /// </summary>
    [Optional]
    [JsonPropertyName("runtime")]
    public string? Runtime { get; set; }

    /// <summary>
    /// The list of secrets that are included in an action or a version of an action.
    /// </summary>
    [Optional]
    [JsonPropertyName("secrets")]
    public IEnumerable<ActionSecretResponse>? Secrets { get; set; }

    [Optional]
    [JsonPropertyName("deployed_version")]
    public ActionDeployedVersion? DeployedVersion { get; set; }

    /// <summary>
    /// installed_integration_id is the fk reference to the InstalledIntegration entity.
    /// </summary>
    [Optional]
    [JsonPropertyName("installed_integration_id")]
    public string? InstalledIntegrationId { get; set; }

    [Optional]
    [JsonPropertyName("integration")]
    public Integration? Integration { get; set; }

    [Optional]
    [JsonPropertyName("status")]
    public ActionBuildStatusEnum? Status { get; set; }

    /// <summary>
    /// The time when this action was built successfully.
    /// </summary>
    [Optional]
    [JsonPropertyName("built_at")]
    public DateTime? BuiltAt { get; set; }

    /// <summary>
    /// True if the action should be deployed after creation.
    /// </summary>
    [Optional]
    [JsonPropertyName("deploy")]
    public bool? Deploy { get; set; }

    /// <summary>
    /// The list of action modules and their versions used by this action.
    /// </summary>
    [Optional]
    [JsonPropertyName("modules")]
    public IEnumerable<ActionModuleReference>? Modules { get; set; }

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
