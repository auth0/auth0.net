using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record TwilioProviderConfiguration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("default_from")]
    public string? DefaultFrom { get; set; }

    [Optional]
    [JsonPropertyName("mssid")]
    public string? Mssid { get; set; }

    [JsonPropertyName("sid")]
    public required string Sid { get; set; }

    [JsonPropertyName("delivery_methods")]
    public IEnumerable<TwilioProviderDeliveryMethodEnum> DeliveryMethods { get; set; } =
        new List<TwilioProviderDeliveryMethodEnum>();

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
