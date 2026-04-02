using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record FormBlockResendButtonConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("active_text")]
    public required string ActiveText { get; set; }

    [JsonPropertyName("button_text")]
    public required string ButtonText { get; set; }

    [JsonPropertyName("waiting_text")]
    public required string WaitingText { get; set; }

    [Optional]
    [JsonPropertyName("text_alignment")]
    public FormBlockResendButtonConfigTextAlignmentEnum? TextAlignment { get; set; }

    [JsonPropertyName("flow_id")]
    public required string FlowId { get; set; }

    [Optional]
    [JsonPropertyName("max_attempts")]
    public double? MaxAttempts { get; set; }

    [Optional]
    [JsonPropertyName("waiting_time")]
    public double? WaitingTime { get; set; }

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
