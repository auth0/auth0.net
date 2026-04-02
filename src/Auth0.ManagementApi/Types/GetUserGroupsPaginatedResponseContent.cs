using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record GetUserGroupsPaginatedResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("groups")]
    public IEnumerable<UserGroupsResponseSchema> Groups { get; set; } =
        new List<UserGroupsResponseSchema>();

    /// <summary>
    /// A cursor to be used as the "from" query parameter for the next page of results.
    /// </summary>
    [Optional]
    [JsonPropertyName("next")]
    public string? Next { get; set; }

    [Optional]
    [JsonPropertyName("start")]
    public double? Start { get; set; }

    [Optional]
    [JsonPropertyName("limit")]
    public double? Limit { get; set; }

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
