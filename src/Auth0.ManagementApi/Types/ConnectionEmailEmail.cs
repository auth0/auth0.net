using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Email template configuration
/// </summary>
[Serializable]
public record ConnectionEmailEmail : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("body")]
    public string? Body { get; set; }

    [Optional]
    [JsonPropertyName("from")]
    public string? From { get; set; }

    [Optional]
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>
    /// Email template syntax type
    /// </summary>
    [Optional]
    [JsonPropertyName("syntax")]
    public string? Syntax { get; set; }

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
