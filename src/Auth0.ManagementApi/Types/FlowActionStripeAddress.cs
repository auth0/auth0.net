using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record FlowActionStripeAddress : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("line1")]
    public string? Line1 { get; set; }

    [Optional]
    [JsonPropertyName("line2")]
    public string? Line2 { get; set; }

    [Optional]
    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; set; }

    [Optional]
    [JsonPropertyName("city")]
    public string? City { get; set; }

    [Optional]
    [JsonPropertyName("state")]
    public string? State { get; set; }

    [Optional]
    [JsonPropertyName("country")]
    public string? Country { get; set; }

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
