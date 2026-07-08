using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'okta' connection
/// </summary>
[Serializable]
public record EventStreamCloudEventConnectionDeletedObject1Options : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// URL of the identity provider's OAuth 2.0 authorization endpoint where users are redirected for authentication. Must be a valid HTTPS URL. This endpoint initiates the OAuth 2.0 authorization code flow.
    /// </summary>
    [Optional]
    [JsonPropertyName("authorization_endpoint")]
    public string? AuthorizationEndpoint { get; set; }

    /// <summary>
    /// OAuth 2.0 client identifier issued by the identity provider during application registration. This value identifies your Auth0 connection to the identity provider.
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    [Optional]
    [JsonPropertyName("connection_settings")]
    public EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettings? ConnectionSettings { get; set; }

    /// <summary>
    /// Email domains associated with this connection for Home Realm Discovery (HRD). When a user's email matches one of these domains, they are automatically routed to this connection during authentication.
    /// </summary>
    [Optional]
    [JsonPropertyName("domain_aliases")]
    public IEnumerable<string>? DomainAliases { get; set; }

    [Optional]
    [JsonPropertyName("dpop_signing_alg")]
    public EventStreamCloudEventConnectionDeletedObject1OptionsDpopSigningAlgEnum? DpopSigningAlg { get; set; }

    [Optional]
    [JsonPropertyName("federated_connections_access_tokens")]
    public EventStreamCloudEventConnectionDeletedObject1OptionsFederatedConnectionsAccessTokens? FederatedConnectionsAccessTokens { get; set; }

    /// <summary>
    /// https url of the icon to be shown
    /// </summary>
    [Optional]
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }

    /// <summary>
    /// Indicates whether the identity provider supports session expiry via the id_token. If true, the system will use the session_expiry claim in the id_token to determine session expiry.
    /// </summary>
    [Optional]
    [JsonPropertyName("id_token_session_expiry_supported")]
    public bool? IdTokenSessionExpirySupported { get; set; }

    /// <summary>
    /// List of algorithms allowed to verify the ID tokens. Applicable when strategy=oidc or okta.
    /// </summary>
    [Optional]
    [JsonPropertyName("id_token_signed_response_algs")]
    public IEnumerable<EventStreamCloudEventConnectionDeletedObject1OptionsIdTokenSignedResponseAlgsItemEnum>? IdTokenSignedResponseAlgs { get; set; }

    /// <summary>
    /// The identity provider's unique issuer identifier URL (e.g., https://accounts.google.com). Must match the 'iss' claim in ID tokens from the identity provider.
    /// </summary>
    [Optional]
    [JsonPropertyName("issuer")]
    public string? Issuer { get; set; }

    /// <summary>
    /// URL of the identity provider's JSON Web Key Set (JWKS) endpoint containing public keys for signature verification. Auth0 retrieves these keys to validate ID token signatures.
    /// </summary>
    [Optional]
    [JsonPropertyName("jwks_uri")]
    public string? JwksUri { get; set; }

    /// <summary>
    /// An array of user fields that should not be stored in the Auth0 database (https://auth0.com/docs/security/data-security/denylist)
    /// </summary>
    [Optional]
    [JsonPropertyName("non_persistent_attrs")]
    public IEnumerable<string>? NonPersistentAttrs { get; set; }

    [Optional]
    [JsonPropertyName("oidc_metadata")]
    public EventStreamCloudEventConnectionDeletedObject1OptionsOidcMetadata? OidcMetadata { get; set; }

    [Optional]
    [JsonPropertyName("schema_version")]
    public EventStreamCloudEventConnectionDeletedObject1OptionsSchemaVersionEnum? SchemaVersion { get; set; }

    /// <summary>
    /// Space-separated list of OAuth 2.0 scopes requested during authorization. Must include 'openid' (required by OIDC spec). Common values: 'openid profile email'. Additional scopes depend on the identity provider.
    /// </summary>
    [Optional]
    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    /// <summary>
    /// When true and type is 'back_channel', includes a cryptographic nonce in authorization requests to prevent replay attacks. The identity provider must include this nonce in the ID token for validation.
    /// </summary>
    [Optional]
    [JsonPropertyName("send_back_channel_nonce")]
    public bool? SendBackChannelNonce { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public EventStreamCloudEventConnectionDeletedObject1OptionsSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    /// <summary>
    /// Tenant domain
    /// </summary>
    [Optional]
    [JsonPropertyName("tenant_domain")]
    public string? TenantDomain { get; set; }

    /// <summary>
    /// URL of the identity provider's OAuth 2.0 token endpoint where authorization codes are exchanged for access tokens. Must be a valid HTTPS URL. Required for authorization code flow but optional for implicit flow.
    /// </summary>
    [Optional]
    [JsonPropertyName("token_endpoint")]
    public string? TokenEndpoint { get; set; }

    [Optional]
    [JsonPropertyName("token_endpoint_auth_method")]
    public EventStreamCloudEventConnectionDeletedObject1OptionsTokenEndpointAuthMethodEnum? TokenEndpointAuthMethod { get; set; }

    [Optional]
    [JsonPropertyName("token_endpoint_auth_signing_alg")]
    public EventStreamCloudEventConnectionDeletedObject1OptionsTokenEndpointAuthSigningAlgEnum? TokenEndpointAuthSigningAlg { get; set; }

    [Optional]
    [JsonPropertyName("token_endpoint_jwtca_aud_format")]
    public EventStreamCloudEventConnectionDeletedObject1OptionsTokenEndpointJwtcaAudFormatEnum? TokenEndpointJwtcaAudFormat { get; set; }

    [Optional]
    [JsonPropertyName("upstream_params")]
    public Dictionary<string, object?>? UpstreamParams { get; set; }

    /// <summary>
    /// Optional URL of the identity provider's UserInfo endpoint. When configured with attribute mapping, Auth0 calls this endpoint to retrieve additional user profile claims using the access token.
    /// </summary>
    [Optional]
    [JsonPropertyName("userinfo_endpoint")]
    public string? UserinfoEndpoint { get; set; }

    [Optional]
    [JsonPropertyName("attribute_map")]
    public EventStreamCloudEventConnectionDeletedObject1OptionsAttributeMap? AttributeMap { get; set; }

    /// <summary>
    /// Domain of the Okta organization (e.g., dev-123456.okta.com). Should be just the domain of the okta server with no scheme or trailing backslash. Discovery runs only when connection.options.oidc_metadata is empty and a domain is provided
    /// </summary>
    [Optional]
    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    [Optional]
    [JsonPropertyName("type")]
    public EventStreamCloudEventConnectionDeletedObject1OptionsTypeEnum? Type { get; set; }

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
