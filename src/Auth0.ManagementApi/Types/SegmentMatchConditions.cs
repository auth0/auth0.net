using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Attribute conditions that must match.
/// </summary>
[Serializable]
public record SegmentMatchConditions : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("client_id")]
    public SegmentMatchExpression? ClientId { get; set; }

    [Optional]
    [JsonPropertyName("connection")]
    public SegmentMatchExpression? Connection { get; set; }

    [Optional]
    [JsonPropertyName("connection_type")]
    public SegmentMatchExpression? ConnectionType { get; set; }

    [Optional]
    [JsonPropertyName("organization_id")]
    public SegmentMatchExpression? OrganizationId { get; set; }

    [Optional]
    [JsonPropertyName("domain")]
    public SegmentMatchExpression? Domain { get; set; }

    [Optional]
    [JsonPropertyName("device_type")]
    public SegmentMatchExpression? DeviceType { get; set; }

    [Optional]
    [JsonPropertyName("browser")]
    public SegmentMatchExpression? Browser { get; set; }

    [Optional]
    [JsonPropertyName("platform")]
    public SegmentMatchExpression? Platform { get; set; }

    [Optional]
    [JsonPropertyName("user_agent")]
    public SegmentMatchExpression? UserAgent { get; set; }

    [Optional]
    [JsonPropertyName("country")]
    public SegmentMatchExpression? Country { get; set; }

    [Optional]
    [JsonPropertyName("region")]
    public SegmentMatchExpression? Region { get; set; }

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
