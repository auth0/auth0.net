using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record ListUserAuthenticationMethodsOffsetPaginatedResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Index of the starting record. Derived from the page and per_page parameters.
    /// </summary>
    [Optional]
    [JsonPropertyName("start")]
    public double? Start { get; set; }

    /// <summary>
    /// Maximum amount of records to return.
    /// </summary>
    [Optional]
    [JsonPropertyName("limit")]
    public double? Limit { get; set; }

    /// <summary>
    /// Total number of pageable records.
    /// </summary>
    [Optional]
    [JsonPropertyName("total")]
    public double? Total { get; set; }

    /// <summary>
    /// The paginated authentication methods. Returned in this structure when include_totals is true.
    /// </summary>
    [Optional]
    [JsonPropertyName("authenticators")]
    public IEnumerable<UserAuthenticationMethod>? Authenticators { get; set; }

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
