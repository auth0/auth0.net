using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record PageComponentAuth0MediaImageConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// URL of the image to display.
    /// </summary>
    [JsonPropertyName("src")]
    public required string Src { get; set; }

    [Optional]
    [JsonPropertyName("position")]
    public Position? Position { get; set; }

    /// <summary>
    /// Height of the image in pixels. Width scales automatically to preserve aspect ratio.
    /// </summary>
    [Optional]
    [JsonPropertyName("height")]
    public int? Height { get; set; }

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
