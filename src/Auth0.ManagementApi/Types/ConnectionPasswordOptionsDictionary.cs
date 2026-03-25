using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Dictionary-based password restriction policy to prevent common passwords
/// </summary>
[Serializable]
public record ConnectionPasswordOptionsDictionary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Enables dictionary checking to prevent use of common passwords and custom blocked words
    /// </summary>
    [Optional]
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    /// <summary>
    /// Array of custom words to block in passwords. Maximum 200 items, each up to 50 characters
    /// </summary>
    [Optional]
    [JsonPropertyName("custom")]
    public IEnumerable<string>? Custom { get; set; }

    [Optional]
    [JsonPropertyName("default")]
    public PasswordDefaultDictionariesEnum? Default { get; set; }

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
