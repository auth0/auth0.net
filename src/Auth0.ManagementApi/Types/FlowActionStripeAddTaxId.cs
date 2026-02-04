using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record FlowActionStripeAddTaxId : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [Optional]
    [JsonPropertyName("alias")]
    public string? Alias { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = "STRIPE";

    [JsonPropertyName("action")]
    public string Action { get; set; } = "ADD_TAX_ID";

    [Optional]
    [JsonPropertyName("allow_failure")]
    public bool? AllowFailure { get; set; }

    [Optional]
    [JsonPropertyName("mask_output")]
    public bool? MaskOutput { get; set; }

    [JsonPropertyName("params")]
    public required FlowActionStripeAddTaxIdParams Params { get; set; }

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
