using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateActionRequestContent
{
    /// <summary>
    /// The name of an action.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The list of triggers that this action supports. At this time, an action can only target a single trigger at a time.
    /// </summary>
    [JsonPropertyName("supported_triggers")]
    public IEnumerable<ActionTrigger> SupportedTriggers { get; set; } = new List<ActionTrigger>();

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
    public IEnumerable<ActionSecretRequest>? Secrets { get; set; }

    /// <summary>
    /// The list of action modules and their versions used by this action.
    /// </summary>
    [Optional]
    [JsonPropertyName("modules")]
    public IEnumerable<ActionModuleReference>? Modules { get; set; }

    /// <summary>
    /// True if the action should be deployed after creation.
    /// </summary>
    [Optional]
    [JsonPropertyName("deploy")]
    public bool? Deploy { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
