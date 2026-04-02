using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record ListAculsOffsetPaginatedResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("configs")]
    public IEnumerable<ListAculsResponseContentItem>? Configs { get; set; }

    /// <summary>
    /// the index of the first configuration in the response (before filtering)
    /// </summary>
    [Optional]
    [JsonPropertyName("start")]
    public double? Start { get; set; }

    /// <summary>
    /// the maximum number of configurations shown per page (before filtering)
    /// </summary>
    [Optional]
    [JsonPropertyName("limit")]
    public double? Limit { get; set; }

    /// <summary>
    /// the total number of configurations on this tenant
    /// </summary>
    [Optional]
    [JsonPropertyName("total")]
    public double? Total { get; set; }

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
