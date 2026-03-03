using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record FlowActionSalesforceCreateLead : IJsonOnDeserialized
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
    public required FlowActionSalesforceCreateLeadType Type { get; set; }

    [JsonPropertyName("action")]
    public required FlowActionSalesforceCreateLeadAction Action { get; set; }

    [Optional]
    [JsonPropertyName("allow_failure")]
    public bool? AllowFailure { get; set; }

    [Optional]
    [JsonPropertyName("mask_output")]
    public bool? MaskOutput { get; set; }

    [JsonPropertyName("params")]
    public required FlowActionSalesforceCreateLeadParams Params { get; set; }

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
