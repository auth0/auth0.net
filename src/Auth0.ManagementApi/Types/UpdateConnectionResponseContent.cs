using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateConnectionResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The name of the connection
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Connection name used in login screen
    /// </summary>
    [Optional]
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

    [Optional]
    [JsonPropertyName("options")]
    public Dictionary<string, object?>? Options { get; set; }

    /// <summary>
    /// The connection's identifier
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The type of the connection, related to the identity provider
    /// </summary>
    [Optional]
    [JsonPropertyName("strategy")]
    public string? Strategy { get; set; }

    /// <summary>
    /// Defines the realms for which the connection will be used (ie: email domains). If the array is empty or the property is not specified, the connection name will be added as realm.
    /// </summary>
    [Optional]
    [JsonPropertyName("realms")]
    public IEnumerable<string>? Realms { get; set; }

    /// <summary>
    /// DEPRECATED property. Use the GET /connections/:id/clients endpoint to get the ids of the clients for which the connection is enabled
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled_clients")]
    public IEnumerable<string>? EnabledClients { get; set; }

    /// <summary>
    /// True if the connection is domain level
    /// </summary>
    [Optional]
    [JsonPropertyName("is_domain_connection")]
    public bool? IsDomainConnection { get; set; }

    /// <summary>
    /// Enables showing a button for the connection in the login page (new experience only). If false, it will be usable only by HRD.
    /// </summary>
    [Optional]
    [JsonPropertyName("show_as_button")]
    public bool? ShowAsButton { get; set; }

    [Optional]
    [JsonPropertyName("metadata")]
    public Dictionary<string, string?>? Metadata { get; set; }

    [Optional]
    [JsonPropertyName("authentication")]
    public ConnectionAuthenticationPurpose? Authentication { get; set; }

    [Optional]
    [JsonPropertyName("connected_accounts")]
    public ConnectionConnectedAccountsPurpose? ConnectedAccounts { get; set; }

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
