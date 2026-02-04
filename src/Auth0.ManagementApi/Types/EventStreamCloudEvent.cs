using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Event content. This will only be set if delivery failed.
/// </summary>
[Serializable]
public record EventStreamCloudEvent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the event
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Where the event originated
    /// </summary>
    [Optional]
    [JsonPropertyName("source")]
    public string? Source { get; set; }

    /// <summary>
    /// Version of CloudEvents spec
    /// </summary>
    [Optional]
    [JsonPropertyName("specversion")]
    public string? Specversion { get; set; }

    /// <summary>
    /// Type of the event (e.g., user.created)
    /// </summary>
    [Optional]
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Timestamp at which the event was generated
    /// </summary>
    [Optional]
    [JsonPropertyName("time")]
    public DateTime? Time { get; set; }

    /// <summary>
    /// Event contents encoded as a string.
    /// </summary>
    [Optional]
    [JsonPropertyName("data")]
    public string? Data { get; set; }

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
