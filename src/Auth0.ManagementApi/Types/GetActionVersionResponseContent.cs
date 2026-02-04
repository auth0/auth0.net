using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record GetActionVersionResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique id of an action version.
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The id of the action to which this version belongs.
    /// </summary>
    [Optional]
    [JsonPropertyName("action_id")]
    public string? ActionId { get; set; }

    /// <summary>
    /// The source code of this specific version of the action.
    /// </summary>
    [Optional]
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    /// The list of third party npm modules, and their versions, that this specific version depends on.
    /// </summary>
    [Optional]
    [JsonPropertyName("dependencies")]
    public IEnumerable<ActionVersionDependency>? Dependencies { get; set; }

    /// <summary>
    /// Indicates if this specific version is the currently one deployed.
    /// </summary>
    [Optional]
    [JsonPropertyName("deployed")]
    public bool? Deployed { get; set; }

    /// <summary>
    /// The Node runtime. For example: `node22`
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
    [JsonPropertyName("status")]
    public ActionVersionBuildStatusEnum? Status { get; set; }

    /// <summary>
    /// The index of this version in list of versions for the action.
    /// </summary>
    [Optional]
    [JsonPropertyName("number")]
    public double? Number { get; set; }

    /// <summary>
    /// Any errors that occurred while the version was being built.
    /// </summary>
    [Optional]
    [JsonPropertyName("errors")]
    public IEnumerable<ActionError>? Errors { get; set; }

    [Optional]
    [JsonPropertyName("action")]
    public ActionBase? Action { get; set; }

    /// <summary>
    /// The time when this version was built successfully.
    /// </summary>
    [Optional]
    [JsonPropertyName("built_at")]
    public DateTime? BuiltAt { get; set; }

    /// <summary>
    /// The time when this version was created.
    /// </summary>
    [Optional]
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The time when a version was updated. Versions are never updated externally. Only Auth0 will update an action version as it is being built.
    /// </summary>
    [Optional]
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// The list of triggers that this version supports. At this time, a version can only target a single trigger at a time.
    /// </summary>
    [Optional]
    [JsonPropertyName("supported_triggers")]
    public IEnumerable<ActionTrigger>? SupportedTriggers { get; set; }

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
