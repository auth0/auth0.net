using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record ListFlowExecutionsPaginatedResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Opaque identifier for use with the <i>from</i> query parameter for the next page of results.<br/>This identifier is valid for 24 hours.
    /// </summary>
    [Optional]
    [JsonPropertyName("next")]
    public string? Next { get; set; }

    [Optional]
    [JsonPropertyName("executions")]
    public IEnumerable<FlowExecutionSummary>? Executions { get; set; }

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
