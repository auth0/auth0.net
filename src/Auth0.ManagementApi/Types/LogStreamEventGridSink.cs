using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record LogStreamEventGridSink : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Subscription ID
    /// </summary>
    [JsonPropertyName("azureSubscriptionId")]
    public required string AzureSubscriptionId { get; set; }

    [JsonPropertyName("azureRegion")]
    public required LogStreamEventGridRegionEnum AzureRegion { get; set; }

    /// <summary>
    /// Resource Group
    /// </summary>
    [JsonPropertyName("azureResourceGroup")]
    public required string AzureResourceGroup { get; set; }

    /// <summary>
    /// Partner Topic
    /// </summary>
    [Optional]
    [JsonPropertyName("azurePartnerTopic")]
    public string? AzurePartnerTopic { get; set; }

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
