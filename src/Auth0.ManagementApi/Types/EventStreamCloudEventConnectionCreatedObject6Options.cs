using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'google-apps' connection
/// </summary>
[Serializable]
public record EventStreamCloudEventConnectionCreatedObject6Options : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Expiration timestamp for the `admin_access_token` in ISO 8601 format. Auth0 uses this value to determine when to refresh the token.
    /// </summary>
    [Optional]
    [JsonPropertyName("admin_access_token_expiresin")]
    public DateTime? AdminAccessTokenExpiresin { get; set; }

    /// <summary>
    /// When true, allows customization of OAuth scopes requested during user login. Custom scopes are appended to the mandatory email and profile scopes. When false or omitted, only the default email and profile scopes are used. This property is automatically enabled when Token Vault or Connected Accounts features are activated.
    /// </summary>
    [Optional]
    [JsonPropertyName("allow_setting_login_scopes")]
    public bool? AllowSettingLoginScopes { get; set; }

    /// <summary>
    /// Enables integration with the Google Workspace Admin SDK Directory API for groups. When true, Auth0 can synchronize groups & group memberships and supports inbound directory provisioning for groups. Defaults to false.
    /// </summary>
    [Optional]
    [JsonPropertyName("api_enable_groups")]
    public bool? ApiEnableGroups { get; set; }

    /// <summary>
    /// Enables integration with the Google Workspace Admin SDK Directory API. When true, Auth0 can retrieve extended user attributes (admin status, suspension status, group memberships) and supports inbound directory provisioning (SCIM). Defaults to true.
    /// </summary>
    [Optional]
    [JsonPropertyName("api_enable_users")]
    public bool? ApiEnableUsers { get; set; }

    /// <summary>
    /// Your Google OAuth 2.0 client ID. You can find this in your [Google Cloud Console](https://console.cloud.google.com/apis/credentials) under the OAuth 2.0 Client IDs section.
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    /// <summary>
    /// Primary Google Workspace domain name that users must belong to.
    /// </summary>
    [Optional]
    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    /// <summary>
    /// Email domains associated with this connection for Home Realm Discovery (HRD). When a user's email matches one of these domains, they are automatically routed to this connection during authentication.
    /// </summary>
    [Optional]
    [JsonPropertyName("domain_aliases")]
    public IEnumerable<string>? DomainAliases { get; set; }

    /// <summary>
    /// Whether the OAuth flow requests the `email` scope.
    /// </summary>
    [Optional]
    [JsonPropertyName("email")]
    public bool? Email { get; set; }

    /// <summary>
    /// Fetches the `agreedToTerms` flag from the Google Directory profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_agreed_terms")]
    public bool? ExtAgreedTerms { get; set; }

    /// <summary>
    /// Enables enrichment with Google group memberships (required for `ext_groups_extended`).
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_groups")]
    public bool? ExtGroups { get; set; }

    /// <summary>
    /// Controls whether enriched group entries include `id`, `email`, `name` (true) or only the group name (false); can only be set when `ext_groups` is true.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_groups_extended")]
    public bool? ExtGroupsExtended { get; set; }

    /// <summary>
    /// Fetches the Google Directory admin flag for the signing-in user.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_is_admin")]
    public bool? ExtIsAdmin { get; set; }

    /// <summary>
    /// Fetches the Google Directory suspended flag for the signing-in user.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_is_suspended")]
    public bool? ExtIsSuspended { get; set; }

    [Optional]
    [JsonPropertyName("federated_connections_access_tokens")]
    public EventStreamCloudEventConnectionCreatedObject6OptionsFederatedConnectionsAccessTokens? FederatedConnectionsAccessTokens { get; set; }

    /// <summary>
    /// When enabled, users who sign in with their Google account through a social login will be automatically routed to this Google Workspace connection if their email domain matches the configured tenant_domain or domain_aliases. This ensures enterprise users authenticate through their organization's Google Workspace identity provider rather than through a generic Google social login, enabling access to directory-based attributes and enforcing organizational security policies. Defaults to true for new connections.
    /// </summary>
    [Optional]
    [JsonPropertyName("handle_login_from_social")]
    public bool? HandleLoginFromSocial { get; set; }

    /// <summary>
    /// URL for the connection icon displayed in Auth0 login pages. Accepts HTTPS URLs. Used for visual branding in authentication flows.
    /// </summary>
    [Optional]
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }

    /// <summary>
    /// Determines how Auth0 generates the user_id for Google Workspace users. When false (default), the user's email address is used. When true, Google's stable numeric user ID is used instead, which persists even if the user's email changes. This setting can only be configured when creating the connection and cannot be changed afterward.
    /// </summary>
    [Optional]
    [JsonPropertyName("map_user_id_to_id")]
    public bool? MapUserIdToId { get; set; }

    /// <summary>
    /// An array of user fields that should not be stored in the Auth0 database (https://auth0.com/docs/security/data-security/denylist)
    /// </summary>
    [Optional]
    [JsonPropertyName("non_persistent_attrs")]
    public IEnumerable<string>? NonPersistentAttrs { get; set; }

    /// <summary>
    /// Whether the OAuth flow requests the `profile` scope.
    /// </summary>
    [Optional]
    [JsonPropertyName("profile")]
    public bool? Profile { get; set; }

    /// <summary>
    /// Additional OAuth scopes requested beyond the default `email profile` scopes; ignored unless `allow_setting_login_scopes` is true.
    /// </summary>
    [Optional]
    [JsonPropertyName("scope")]
    public IEnumerable<string>? Scope { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public EventStreamCloudEventConnectionCreatedObject6OptionsSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    /// <summary>
    /// The Google Workspace primary domain used to identify the organization during authentication.
    /// </summary>
    [Optional]
    [JsonPropertyName("tenant_domain")]
    public string? TenantDomain { get; set; }

    [Optional]
    [JsonPropertyName("upstream_params")]
    public Dictionary<string, object?>? UpstreamParams { get; set; }

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
