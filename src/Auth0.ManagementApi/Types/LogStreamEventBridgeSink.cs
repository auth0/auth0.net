using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record LogStreamEventBridgeSink : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// AWS account ID
    /// </summary>
    [JsonPropertyName("awsAccountId")]
    public required string AwsAccountId { get; set; }

    [JsonPropertyName("awsRegion")]
    public required LogStreamEventBridgeSinkRegionEnum AwsRegion { get; set; }

    /// <summary>
    /// AWS EventBridge partner event source
    /// </summary>
    [Optional]
    [JsonPropertyName("awsPartnerEventSource")]
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
