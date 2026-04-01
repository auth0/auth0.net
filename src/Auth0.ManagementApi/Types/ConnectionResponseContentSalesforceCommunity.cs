using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Response for connections with strategy=salesforce-community
/// </summary>
[Serializable]
public record ConnectionResponseContentSalesforceCommunity : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("strategy")]
    public required ConnectionResponseContentSalesforceCommunityStrategy Strategy { get; set; }

    [Optional]
    [JsonPropertyName("options")]
    public ConnectionOptionsSalesforceCommunity? Options { get; set; }

    [Optional]
    [JsonPropertyName("authentication")]
    public ConnectionAuthenticationPurpose? Authentication { get; set; }

    [Optional]
    [JsonPropertyName("connected_accounts")]
    public ConnectionConnectedAccountsPurpose? ConnectedAccounts { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [Optional]
    [JsonPropertyName("realms")]
    public IEnumerable<string>? Realms { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Use of this property is NOT RECOMMENDED. Use the PATCH /v2/connections/{id}/clients endpoint to enable the connection for a set of clients.
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled_clients")]
    public IEnumerable<string>? EnabledClients { get; set; }

    [Optional]
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

    [Optional]
    [JsonPropertyName("is_domain_connection")]
    public bool? IsDomainConnection { get; set; }

    [Optional]
    [JsonPropertyName("metadata")]
    public Dictionary<string, string?>? Metadata { get; set; }

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
