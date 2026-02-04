using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// The result of a specific execution of a trigger.
/// </summary>
[Serializable]
public record GetActionExecutionResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ID identifies this specific execution simulation. These IDs would resemble real executions in production.
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [Optional]
    [JsonPropertyName("trigger_id")]
    public string? TriggerId { get; set; }

    [Optional]
    [JsonPropertyName("status")]
    public ActionExecutionStatusEnum? Status { get; set; }

    [Optional]
    [JsonPropertyName("results")]
    public IEnumerable<ActionExecutionResult>? Results { get; set; }

    /// <summary>
    /// The time that the execution was started.
    /// </summary>
    [Optional]
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The time that the exeution finished executing.
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
