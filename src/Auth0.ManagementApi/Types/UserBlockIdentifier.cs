using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UserBlockIdentifier : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Identifier (should be any of an `email`, `username`, or `phone_number`)
    /// </summary>
    [Optional]
    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    /// <summary>
    /// IP Address
    /// </summary>
    [Optional]
    [JsonPropertyName("ip")]
    public string? Ip { get; set; }

    /// <summary>
    /// Connection identifier
    /// </summary>
    [Optional]
    [JsonPropertyName("connection")]
    public string? Connection { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
