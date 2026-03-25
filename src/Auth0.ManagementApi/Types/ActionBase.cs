using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The action to which this version belongs.
/// </summary>
[Serializable]
public record ActionBase : IJsonOnDeserialized
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
