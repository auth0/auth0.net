using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record EventStreamCloudEventConnectionDeletedObject6 : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("authentication")]
    public EventStreamCloudEventConnectionDeletedObject6Authentication? Authentication { get; set; }

    [Optional]
    [JsonPropertyName("connected_accounts")]
    public EventStreamCloudEventConnectionDeletedObject6ConnectedAccounts? ConnectedAccounts { get; set; }

    /// <summary>
    /// Connection name used in the new universal login experience
    /// </summary>
    [Optional]
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// Use of this property is NOT RECOMMENDED. Use the PATCH /v2/connections/{id}/clients endpoint to enable the connection for a set of clients.
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled_clients")]
    public IEnumerable<string>? EnabledClients { get; set; }

    /// <summary>
    /// The connection's identifier
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// <c>true</c> promotes to a domain-level connection so that third-party applications can use it. <c>false</c> does not promote the connection, so only first-party applications with the connection enabled can use it. (Defaults to <c>false</c>.)
    /// </summary>
    [Optional]
    [JsonPropertyName("is_domain_connection")]
    public bool? IsDomainConnection { get; set; }

    [Optional]
    [JsonPropertyName("metadata")]
    public EventStreamCloudEventConnectionDeletedObject6Metadata? Metadata { get; set; }

    /// <summary>
    /// The name of the connection. Must start and end with an alphanumeric character and can only contain alphanumeric characters and '-'. Max length 128
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Defines the realms for which the connection will be used (ie: email domains). If the array is empty or the property is not specified, the connection name will be added as realm.
    /// </summary>
    [Optional]
    [JsonPropertyName("realms")]
    public IEnumerable<string>? Realms { get; set; }

    [Optional]
    [JsonPropertyName("options")]
    public EventStreamCloudEventConnectionDeletedObject6Options? Options { get; set; }

    /// <summary>
    /// Enables showing a button for the connection in the login page (new experience only). If false, it will be usable only by HRD. Defaults to `false`.
    /// </summary>
    [Optional]
    [JsonPropertyName("show_as_button")]
    public bool? ShowAsButton { get; set; }

    [JsonPropertyName("strategy")]
    public required EventStreamCloudEventConnectionDeletedObject6StrategyEnum Strategy { get; set; }

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
