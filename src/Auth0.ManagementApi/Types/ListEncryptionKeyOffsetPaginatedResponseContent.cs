using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record ListEncryptionKeyOffsetPaginatedResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Page index of the results to return. First page is 0.
    /// </summary>
    [Optional]
    [JsonPropertyName("start")]
    public int? Start { get; set; }

    /// <summary>
    /// Number of results per page.
    /// </summary>
    [Optional]
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// Total amount of encryption keys.
    /// </summary>
    [Optional]
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// Encryption keys.
    /// </summary>
    [Optional]
    [JsonPropertyName("keys")]
    public IEnumerable<EncryptionKey>? Keys { get; set; }

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
