using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record GetFormResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [Optional]
    [JsonPropertyName("messages")]
    public FormMessages? Messages { get; set; }

    [Optional]
    [JsonPropertyName("languages")]
    public FormLanguages? Languages { get; set; }

    [Optional]
    [JsonPropertyName("translations")]
    public Dictionary<string, Dictionary<string, object?>>? Translations { get; set; }

    [Optional]
    [JsonPropertyName("nodes")]
    public IEnumerable<FormNode>? Nodes { get; set; }

    [Optional]
    [JsonPropertyName("start")]
    public FormStartNode? Start { get; set; }

    [Optional]
    [JsonPropertyName("ending")]
    public FormEndingNode? Ending { get; set; }

    [Optional]
    [JsonPropertyName("style")]
    public FormStyle? Style { get; set; }

    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

    [Optional]
    [JsonPropertyName("embedded_at")]
    public string? EmbeddedAt { get; set; }

    [Optional]
    [JsonPropertyName("submitted_at")]
    public string? SubmittedAt { get; set; }

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
