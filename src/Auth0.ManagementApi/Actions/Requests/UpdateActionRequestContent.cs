using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateActionRequestContent
{
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
