using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Captures the results of a single action being executed.
/// </summary>
[Serializable]
public record ActionExecutionResult : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The name of the action that was executed.
    /// </summary>
    [Optional]
    [JsonPropertyName("action_name")]
    public string? ActionName { get; set; }

    [Optional]
    [JsonPropertyName("error")]
    public ActionError? Error { get; set; }

    /// <summary>
    /// The time when the action was started.
    /// </summary>
    [Optional]
    [JsonPropertyName("started_at")]
    public DateTime? StartedAt { get; set; }

    /// <summary>
    /// The time when the action finished executing.
    /// </summary>
    [Optional]
    [JsonPropertyName("ended_at")]
    public DateTime? EndedAt { get; set; }

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
