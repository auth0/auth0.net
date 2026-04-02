using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Configuration specific to an eventbridge destination.
/// </summary>
[Serializable]
public record EventStreamEventBridgeConfiguration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// AWS Account ID for EventBridge destination.
    /// </summary>
    [JsonPropertyName("aws_account_id")]
    public required string AwsAccountId { get; set; }

    [JsonPropertyName("aws_region")]
    public required EventStreamEventBridgeAwsRegionEnum AwsRegion { get; set; }

    /// <summary>
    /// AWS Partner Event Source for EventBridge destination.
    /// </summary>
    [Optional]
    [JsonPropertyName("aws_partner_event_source")]
    public string? AwsPartnerEventSource { get; set; }

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
