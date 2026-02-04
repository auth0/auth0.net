using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record FormFieldCustomConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("schema")]
    public Dictionary<string, object?> Schema { get; set; } = new Dictionary<string, object?>();

    [JsonPropertyName("code")]
    public required string Code { get; set; }

    [Optional]
    [JsonPropertyName("css")]
    public string? Css { get; set; }

    [Optional]
    [JsonPropertyName("params")]
    public Dictionary<string, string>? Params { get; set; }

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
