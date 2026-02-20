using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'google-apps' connection
/// </summary>
[Serializable]
public record ConnectionOptionsGoogleApps : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("admin_access_token")]
    public string? AdminAccessToken { get; set; }

    [Optional]
    [JsonPropertyName("admin_access_token_expiresin")]
    public DateTime? AdminAccessTokenExpiresin { get; set; }

    [Optional]
    [JsonPropertyName("admin_refresh_token")]
    public string? AdminRefreshToken { get; set; }

    /// <summary>
    /// When true, allows customization of OAuth scopes requested during user login. Custom scopes are appended to the mandatory email and profile scopes. When false or omitted, only the default email and profile scopes are used. This property is automatically enabled when Token Vault or Connected Accounts features are activated.
    /// </summary>
    [Optional]
    [JsonPropertyName("allow_setting_login_scopes")]
    public bool? AllowSettingLoginScopes { get; set; }

    [Optional]
    [JsonPropertyName("api_enable_users")]
    public bool? ApiEnableUsers { get; set; }

    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    [Optional]
    [JsonPropertyName("client_secret")]
    public string? ClientSecret { get; set; }

    [Optional]
    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    [Optional]
    [JsonPropertyName("domain_aliases")]
    public IEnumerable<string>? DomainAliases { get; set; }

    /// <summary>
    /// Whether the OAuth flow requests the `email` scope.
    /// </summary>
    [Optional]
    [JsonPropertyName("email")]
    public bool? Email { get; set; }

    [Optional]
    [JsonPropertyName("ext_agreed_terms")]
    public bool? ExtAgreedTerms { get; set; }

    [Optional]
    [JsonPropertyName("ext_groups")]
    public bool? ExtGroups { get; set; }

    /// <summary>
    /// Controls whether enriched group entries include `id`, `email`, `name` (true) or only the group name (false); can only be set when `ext_groups` is true.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_groups_extended")]
    public bool? ExtGroupsExtended { get; set; }

    [Optional]
    [JsonPropertyName("ext_is_admin")]
    public bool? ExtIsAdmin { get; set; }

    [Optional]
    [JsonPropertyName("ext_is_suspended")]
    public bool? ExtIsSuspended { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("federated_connections_access_tokens")]
    public Optional<ConnectionFederatedConnectionsAccessTokens?> FederatedConnectionsAccessTokens { get; set; }

    [Optional]
    [JsonPropertyName("handle_login_from_social")]
    public bool? HandleLoginFromSocial { get; set; }

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
    /// Whether the OAuth flow requests the `profile` scope.
    /// </summary>
    [Optional]
    [JsonPropertyName("profile")]
    public bool? Profile { get; set; }

    [Optional]
    [JsonPropertyName("scope")]
    public IEnumerable<string>? Scope { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public ConnectionSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    [Optional]
    [JsonPropertyName("tenant_domain")]
    public string? TenantDomain { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("upstream_params")]
    public Optional<Dictionary<
        string,
        ConnectionUpstreamAdditionalProperties?
    >?> UpstreamParams { get; set; }

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
