using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record FormFieldChoiceConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("multiple")]
    public bool? Multiple { get; set; }

    [Optional]
    [JsonPropertyName("options")]
    public IEnumerable<FormFieldChoiceConfigOption>? Options { get; set; }

    [Optional]
    [JsonPropertyName("allow_other")]
    public FormFieldChoiceConfigAllowOther? AllowOther { get; set; }

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
