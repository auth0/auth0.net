using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateConnectionRequestContent
{
    /// <summary>
    /// The connection name used in the new universal login experience. If display_name is not included in the request, the field will be overwritten with the name value.
    /// </summary>
    [Optional]
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("options")]
    public Optional<UpdateConnectionOptions?> Options { get; set; }

    /// <summary>
    /// DEPRECATED property. Use the PATCH /v2/connections/{id}/clients endpoint to enable or disable the connection for any clients.
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled_clients")]
    public IEnumerable<string>? EnabledClients { get; set; }

    /// <summary>
    /// <code>true</code> promotes to a domain-level connection so that third-party applications can use it. <code>false</code> does not promote the connection, so only first-party applications with the connection enabled can use it. (Defaults to <code>false</code>.)
    /// </summary>
    [Optional]
    [JsonPropertyName("is_domain_connection")]
    public bool? IsDomainConnection { get; set; }

    /// <summary>
    /// Enables showing a button for the connection in the login page (new experience only). If false, it will be usable only by HRD. (Defaults to <code>false</code>.)
    /// </summary>
    [Optional]
    [JsonPropertyName("show_as_button")]
    public bool? ShowAsButton { get; set; }

    /// <summary>
    /// Defines the realms for which the connection will be used (ie: email domains). If the array is empty or the property is not specified, the connection name will be added as realm.
    /// </summary>
    [Optional]
    [JsonPropertyName("realms")]
    public IEnumerable<string>? Realms { get; set; }

    [Optional]
    [JsonPropertyName("metadata")]
    public Dictionary<string, string?>? Metadata { get; set; }

    [Optional]
    [JsonPropertyName("authentication")]
    public ConnectionAuthenticationPurpose? Authentication { get; set; }

    [Optional]
    [JsonPropertyName("connected_accounts")]
    public ConnectionConnectedAccountsPurpose? ConnectedAccounts { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
