using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateFormRequestContent
{
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
