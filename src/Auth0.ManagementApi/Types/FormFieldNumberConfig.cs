using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record FormFieldNumberConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("default_value")]
    public double? DefaultValue { get; set; }

    [Optional]
    [JsonPropertyName("placeholder")]
    public string? Placeholder { get; set; }

    [Optional]
    [JsonPropertyName("min_value")]
    public double? MinValue { get; set; }

    [Optional]
    [JsonPropertyName("max_value")]
    public double? MaxValue { get; set; }

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
