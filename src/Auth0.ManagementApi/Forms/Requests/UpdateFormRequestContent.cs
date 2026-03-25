using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateFormRequestContent
{
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("messages")]
    public Optional<FormMessages?> Messages { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("languages")]
    public Optional<FormLanguages?> Languages { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("translations")]
    public Optional<Dictionary<string, Dictionary<string, object?>>?> Translations { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("nodes")]
    public Optional<IEnumerable<FormNode>?> Nodes { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("start")]
    public Optional<FormStartNode?> Start { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("ending")]
    public Optional<FormEndingNode?> Ending { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("style")]
    public Optional<FormStyle?> Style { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
