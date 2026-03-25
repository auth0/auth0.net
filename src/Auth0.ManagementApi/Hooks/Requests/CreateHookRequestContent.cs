using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateHookRequestContent
{
    /// <summary>
    /// Name of this hook.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Code to be executed when this hook runs.
    /// </summary>
    [JsonPropertyName("script")]
    public required string Script { get; set; }

    /// <summary>
    /// Whether this hook will be executed (true) or ignored (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [Optional]
    [JsonPropertyName("dependencies")]
    public Dictionary<string, string>? Dependencies { get; set; }

    /// <summary>
    /// Execution stage of this rule. Can be `credentials-exchange`, `pre-user-registration`, `post-user-registration`, `post-change-password`, or `send-phone-message`.
    /// </summary>
    [JsonPropertyName("triggerId")]
    public required HookTriggerIdEnum TriggerId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
