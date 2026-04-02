using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record FormFieldPaymentConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("provider")]
    public FormFieldPaymentConfigProviderEnum? Provider { get; set; }

    [JsonPropertyName("charge")]
    public required FormFieldPaymentConfigCharge Charge { get; set; }

    [JsonPropertyName("credentials")]
    public required FormFieldPaymentConfigCredentials Credentials { get; set; }

    [Optional]
    [JsonPropertyName("customer")]
    public Dictionary<string, object?>? Customer { get; set; }

    [Optional]
    [JsonPropertyName("fields")]
    public FormFieldPaymentConfigFields? Fields { get; set; }

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
