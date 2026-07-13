using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'waad' connection
/// </summary>
[Serializable]
public record EventStreamCloudEventConnectionCreatedObject7Options : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Enable users API
    /// </summary>
    [Optional]
    [JsonPropertyName("api_enable_users")]
    public bool? ApiEnableUsers { get; set; }

    /// <summary>
    /// The Azure AD application domain (e.g., 'contoso.onmicrosoft.com'). Used primarily with WS-Federation protocol and Azure AD v1 endpoints.
    /// </summary>
    [Optional]
    [JsonPropertyName("app_domain")]
    public string? AppDomain { get; set; }

    /// <summary>
    /// The Application ID URI (App ID URI) for the Azure AD application. Required when using Azure AD v1 with the Resource Owner Password flow. Used to identify the resource being requested in OAuth token requests.
    /// </summary>
    [Optional]
    [JsonPropertyName("app_id")]
    public string? AppId { get; set; }

    /// <summary>
    /// Includes basic user profile information from Azure AD (name, email, given_name, family_name). Always enabled and required - represents the minimum profile data retrieved during authentication.
    /// </summary>
    [Optional]
    [JsonPropertyName("basic_profile")]
    public bool? BasicProfile { get; set; }

    /// <summary>
    /// Timestamp of the last certificate expiring soon notification.
    /// </summary>
    [Optional]
    [JsonPropertyName("cert_rollover_notification")]
    public DateTime? CertRolloverNotification { get; set; }

    /// <summary>
    /// OAuth 2.0 client identifier issued by the identity provider during application registration. This value identifies your Auth0 connection to the identity provider.
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    /// <summary>
    /// The primary Azure AD tenant domain (e.g., 'contoso.onmicrosoft.com' or 'contoso.com').
    /// </summary>
    [Optional]
    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    /// <summary>
    /// Alternative domain names associated with this Azure AD tenant. Allows users from multiple verified domains to authenticate through this connection. Can be an array of domain strings.
    /// </summary>
    [Optional]
    [JsonPropertyName("domain_aliases")]
    public IEnumerable<string>? DomainAliases { get; set; }

    /// <summary>
    /// When enabled (true), retrieves and stores Azure AD security group memberships for the user. Requires Microsoft Graph API permissions (Directory.Read.All). Allows configuring max_groups_to_retrieve.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_groups")]
    public bool? ExtGroups { get; set; }

    /// <summary>
    /// When true, stores all groups the user is member of, including transitive group memberships (groups within groups). When false (default), only direct group memberships are included.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_nested_groups")]
    public bool? ExtNestedGroups { get; set; }

    /// <summary>
    /// When enabled (true), retrieves extended profile attributes from Azure AD via Microsoft Graph API (job title, department, office location, etc.). Requires Graph API permissions. Only available with Azure AD v1 or when explicitly enabled for v2.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_profile")]
    public bool? ExtProfile { get; set; }

    [Optional]
    [JsonPropertyName("federated_connections_access_tokens")]
    public EventStreamCloudEventConnectionCreatedObject7OptionsFederatedConnectionsAccessTokens? FederatedConnectionsAccessTokens { get; set; }

    /// <summary>
    /// Indicates whether admin consent has been granted for the required Azure AD permissions. Read-only status field managed by Auth0 during the OAuth authorization flow.
    /// </summary>
    [Optional]
    [JsonPropertyName("granted")]
    public bool? Granted { get; set; }

    /// <summary>
    /// URL for the connection icon displayed in Auth0 login pages. Accepts HTTPS URLs. Used for visual branding in authentication flows.
    /// </summary>
    [Optional]
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }

    [Optional]
    [JsonPropertyName("identity_api")]
    public EventStreamCloudEventConnectionCreatedObject7OptionsIdentityApiEnum? IdentityApi { get; set; }

    /// <summary>
    /// Maximum number of Azure AD groups to retrieve per user during authentication. Helps prevent performance issues for users in many groups. Only applies when ext_groups is enabled. Leave empty to use platform default.
    /// </summary>
    [Optional]
    [JsonPropertyName("max_groups_to_retrieve")]
    public string? MaxGroupsToRetrieve { get; set; }

    /// <summary>
    /// An array of user fields that should not be stored in the Auth0 database (https://auth0.com/docs/security/data-security/denylist)
    /// </summary>
    [Optional]
    [JsonPropertyName("non_persistent_attrs")]
    public IEnumerable<string>? NonPersistentAttrs { get; set; }

    /// <summary>
    /// OAuth 2.0 scopes to request from Azure AD during authentication. Each scope represents a permission (e.g., 'User.Read', 'Group.Read.All'). Only applies with Microsoft Identity Platform v2.0. See Microsoft Graph permissions reference for available scopes.
    /// </summary>
    [Optional]
    [JsonPropertyName("scope")]
    public IEnumerable<string>? Scope { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public EventStreamCloudEventConnectionCreatedObject7OptionsSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    [Optional]
    [JsonPropertyName("should_trust_email_verified_connection")]
    public EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum? ShouldTrustEmailVerifiedConnection { get; set; }

    [Optional]
    [JsonPropertyName("tenant_domain")]
    public string? TenantDomain { get; set; }

    /// <summary>
    /// The Azure AD tenant ID as a UUID. The unique identifier for your Azure AD organization. Must be a valid 36-character UUID.
    /// </summary>
    [Optional]
    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    /// <summary>
    /// Array of certificate thumbprints (SHA-128/SHA-256/SHA-512 hex hashes) for validating SAML signatures. Used with WS-Federation protocol. Maximum 20 thumbprints. Each thumbprint must be a hexadecimal string.
    /// </summary>
    [Optional]
    [JsonPropertyName("thumbprints")]
    public IEnumerable<string>? Thumbprints { get; set; }

    [Optional]
    [JsonPropertyName("upstream_params")]
    public Dictionary<string, object?>? UpstreamParams { get; set; }

    /// <summary>
    /// Indicates WS-Federation protocol usage. When true, uses WS-Federation; when false, uses OpenID Connect.
    /// </summary>
    [Optional]
    [JsonPropertyName("use_wsfed")]
    public bool? UseWsfed { get; set; }

    /// <summary>
    /// When enabled (true), uses the Azure AD common endpoint for multi-tenant authentication. Allows users from any Azure AD organization to sign in. Requires userid_attribute set to 'sub' (not 'oid'). Cannot be used with SCIM provisioning. Defaults to false.
    /// </summary>
    [Optional]
    [JsonPropertyName("useCommonEndpoint")]
    public bool? UseCommonEndpoint { get; set; }

    [Optional]
    [JsonPropertyName("userid_attribute")]
    public EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnum? UseridAttribute { get; set; }

    [Optional]
    [JsonPropertyName("waad_protocol")]
    public EventStreamCloudEventConnectionCreatedObject7OptionsWaadProtocolEnum? WaadProtocol { get; set; }

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
