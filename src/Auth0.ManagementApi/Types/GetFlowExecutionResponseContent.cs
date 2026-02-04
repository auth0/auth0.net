using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record GetFlowExecutionResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Flow execution identifier
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Trace id
    /// </summary>
    [JsonPropertyName("trace_id")]
    public required string TraceId { get; set; }

    /// <summary>
    /// Journey id
    /// </summary>
    [Optional]
    [JsonPropertyName("journey_id")]
    public string? JourneyId { get; set; }

    /// <summary>
    /// Execution status
    /// </summary>
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [Optional]
    [JsonPropertyName("debug")]
    public Dictionary<string, object?>? Debug { get; set; }

    /// <summary>
    /// The ISO 8601 formatted date when this flow execution was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The ISO 8601 formatted date when this flow execution was updated.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// The ISO 8601 formatted date when this flow execution started.
    /// </summary>
    [Optional]
    [JsonPropertyName("started_at")]
    public DateTime? StartedAt { get; set; }

    /// <summary>
    /// The ISO 8601 formatted date when this flow execution ended.
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
