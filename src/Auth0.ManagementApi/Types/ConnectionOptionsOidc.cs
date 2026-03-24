using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'oidc' connection
/// </summary>
[Serializable]
public record ConnectionOptionsOidc : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("attribute_map")]
    public ConnectionAttributeMapOidc? AttributeMap { get; set; }

    [Optional]
    [JsonPropertyName("discovery_url")]
    public string? DiscoveryUrl { get; set; }

    [Optional]
    [JsonPropertyName("type")]
    public ConnectionTypeEnumOidc? Type { get; set; }

    [Optional]
    [JsonPropertyName("authorization_endpoint")]
    public string? AuthorizationEndpoint { get; set; }

    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    [Optional]
    [JsonPropertyName("client_secret")]
    public string? ClientSecret { get; set; }

    [Optional]
    [JsonPropertyName("connection_settings")]
    public ConnectionConnectionSettings? ConnectionSettings { get; set; }

    [Optional]
    [JsonPropertyName("domain_aliases")]
    public IEnumerable<string>? DomainAliases { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("federated_connections_access_tokens")]
    public Optional<ConnectionFederatedConnectionsAccessTokens?> FederatedConnectionsAccessTokens { get; set; }

    [Optional]
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("id_token_signed_response_algs")]
    public Optional<IEnumerable<ConnectionIdTokenSignedResponseAlgEnum>?> IdTokenSignedResponseAlgs { get; set; }

    [Optional]
    [JsonPropertyName("issuer")]
    public string? Issuer { get; set; }

    [Optional]
    [JsonPropertyName("jwks_uri")]
    public string? JwksUri { get; set; }

    [Optional]
    [JsonPropertyName("oidc_metadata")]
    public ConnectionOptionsOidcMetadata? OidcMetadata { get; set; }

    [Optional]
    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    [Optional]
    [JsonPropertyName("send_back_channel_nonce")]
    public bool? SendBackChannelNonce { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public ConnectionSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    [Optional]
    [JsonPropertyName("tenant_domain")]
    public string? TenantDomain { get; set; }

    [Optional]
    [JsonPropertyName("token_endpoint")]
    public string? TokenEndpoint { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("token_endpoint_auth_method")]
    public Optional<ConnectionTokenEndpointAuthMethodEnum?> TokenEndpointAuthMethod { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("token_endpoint_auth_signing_alg")]
    public Optional<ConnectionTokenEndpointAuthSigningAlgEnum?> TokenEndpointAuthSigningAlg { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("upstream_params")]
    public Optional<Dictionary<
        string,
        ConnectionUpstreamAdditionalProperties?
    >?> UpstreamParams { get; set; }

    [Optional]
    [JsonPropertyName("userinfo_endpoint")]
    public string? UserinfoEndpoint { get; set; }

    [Optional]
    [JsonPropertyName("non_persistent_attrs")]
    public IEnumerable<string>? NonPersistentAttrs { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
