using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record FormFieldPasswordConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("hash")]
    public FormFieldPasswordConfigHashEnum? Hash { get; set; }

    [Optional]
    [JsonPropertyName("placeholder")]
    public string? Placeholder { get; set; }

    [Optional]
    [JsonPropertyName("min_length")]
    public int? MinLength { get; set; }

    [Optional]
    [JsonPropertyName("max_length")]
    public int? MaxLength { get; set; }

    [Optional]
    [JsonPropertyName("complexity")]
    public bool? Complexity { get; set; }

    [Optional]
    [JsonPropertyName("nist")]
    public bool? Nist { get; set; }

    [Optional]
    [JsonPropertyName("strength_meter")]
    public bool? StrengthMeter { get; set; }

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
