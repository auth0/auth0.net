using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record FlowActionWhatsappSendMessageParams : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("connection_id")]
    public required string ConnectionId { get; set; }

    [JsonPropertyName("sender_id")]
    public required string SenderId { get; set; }

    [JsonPropertyName("recipient_number")]
    public required string RecipientNumber { get; set; }

    [JsonPropertyName("type")]
    public required FlowActionWhatsappSendMessageParamsType Type { get; set; }

    [JsonPropertyName("payload")]
    public required FlowActionWhatsappSendMessageParamsPayload Payload { get; set; }

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
