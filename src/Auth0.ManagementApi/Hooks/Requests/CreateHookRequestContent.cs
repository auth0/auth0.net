using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

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

    [JsonPropertyName("triggerId")]
    public required HookTriggerIdEnum TriggerId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
