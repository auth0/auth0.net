using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record EventStreamDeliveryAttempt : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("status")]
    public string Status { get; set; } = "failed";

    /// <summary>
    /// Timestamp of delivery attempt
    /// </summary>
    [JsonPropertyName("timestamp")]
    public required DateTime Timestamp { get; set; }

    /// <summary>
    /// Delivery error message, if applicable
    /// </summary>
    [Optional]
    [JsonPropertyName("error_message")]
    public string? ErrorMessage { get; set; }

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
