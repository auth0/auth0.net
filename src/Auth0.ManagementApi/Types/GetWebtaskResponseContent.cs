using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// A webtask in the tenant's container, as returned by the webtask platform's GET. Code and decrypted secrets are only included when requested.
/// </summary>
[Serializable]
public record GetWebtaskResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// JavaScript code of the webtask. Only returned with <c>fetch_code=true</c>.
    /// </summary>
    [Optional]
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [Optional]
    [JsonPropertyName("secrets")]
    public Dictionary<string, string>? Secrets { get; set; }

    [JsonPropertyName("container")]
    public required string Container { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [Optional]
    [JsonPropertyName("token")]
    public string? Token { get; set; }

    [JsonPropertyName("meta")]
    public Dictionary<string, string> Meta { get; set; } = new Dictionary<string, string>();

    [Optional]
    [JsonPropertyName("webtask_url")]
    public string? WebtaskUrl { get; set; }

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
