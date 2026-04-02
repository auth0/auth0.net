using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record FormFieldPaymentConfigFields : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("card_number")]
    public FormFieldPaymentConfigFieldProperties? CardNumber { get; set; }

    [Optional]
    [JsonPropertyName("expiration_date")]
    public FormFieldPaymentConfigFieldProperties? ExpirationDate { get; set; }

    [Optional]
    [JsonPropertyName("security_code")]
    public FormFieldPaymentConfigFieldProperties? SecurityCode { get; set; }

    [Optional]
    [JsonPropertyName("trustmarks")]
    public bool? Trustmarks { get; set; }

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
