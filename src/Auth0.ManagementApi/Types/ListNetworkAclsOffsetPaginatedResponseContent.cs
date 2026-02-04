using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record ListNetworkAclsOffsetPaginatedResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("network_acls")]
    public IEnumerable<NetworkAclsResponseContent>? NetworkAcls { get; set; }

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
