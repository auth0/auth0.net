using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Response for connections with strategy=bitly
/// </summary>
[Serializable]
public record ConnectionResponseContentBitly : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("strategy")]
    public string Strategy { get; set; } = "bitly";

    [Optional]
    [JsonPropertyName("options")]
    public ConnectionOptionsOAuth2Common? Options { get; set; }

    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Optional]
    [JsonPropertyName("authentication")]
    public ConnectionAuthenticationPurpose? Authentication { get; set; }

    [Optional]
    [JsonPropertyName("connected_accounts")]
    public ConnectionConnectedAccountsPurpose? ConnectedAccounts { get; set; }

    [Optional]
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

    [Optional]
    [JsonPropertyName("enabled_clients")]
    public IEnumerable<string>? EnabledClients { get; set; }

    [Optional]
    [JsonPropertyName("is_domain_connection")]
    public bool? IsDomainConnection { get; set; }

    [Optional]
    [JsonPropertyName("metadata")]
    public Dictionary<string, string?>? Metadata { get; set; }

    [Optional]
    [JsonPropertyName("realms")]
    public IEnumerable<string>? Realms { get; set; }

    [Optional]
    [JsonPropertyName("show_as_button")]
    public bool? ShowAsButton { get; set; }

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
