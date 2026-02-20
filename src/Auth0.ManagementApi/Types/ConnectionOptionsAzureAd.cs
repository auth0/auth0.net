using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'waad' connection
/// </summary>
[Serializable]
public record ConnectionOptionsAzureAd : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Enable users API
    /// </summary>
    [Optional]
    [JsonPropertyName("api_enable_users")]
    public bool? ApiEnableUsers { get; set; }

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

    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    [Optional]
    [JsonPropertyName("client_secret")]
    public string? ClientSecret { get; set; }

    [Optional]
    [JsonPropertyName("domain_aliases")]
    public IEnumerable<string>? DomainAliases { get; set; }

    /// <summary>
    /// When false, prevents storing the user's Azure AD access token in the Auth0 user profile. When true (default), the access token is persisted for API access.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_access_token")]
    public bool? ExtAccessToken { get; set; }

    /// <summary>
    /// When false, prevents storing whether the user's Azure AD account is enabled. When true (default), the account enabled status is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_account_enabled")]
    public bool? ExtAccountEnabled { get; set; }

    [Optional]
    [JsonPropertyName("ext_admin")]
    public bool? ExtAdmin { get; set; }

    [Optional]
    [JsonPropertyName("ext_agreed_terms")]
    public bool? ExtAgreedTerms { get; set; }

    /// <summary>
    /// When false, prevents storing the list of Microsoft 365/Office 365 licenses assigned to the user. When true (default), license information is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_assigned_licenses")]
    public bool? ExtAssignedLicenses { get; set; }

    [Optional]
    [JsonPropertyName("ext_assigned_plans")]
    public bool? ExtAssignedPlans { get; set; }

    /// <summary>
    /// When false, prevents storing the user's Azure ID identifier. When true (default), the Azure ID is persisted. Note: 'oid' (Object ID) is the recommended unique identifier for single-tenant connections.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_azure_id")]
    public bool? ExtAzureId { get; set; }

    /// <summary>
    /// When false, prevents storing the user's city from Azure AD. When true (default), city information is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_city")]
    public bool? ExtCity { get; set; }

    /// <summary>
    /// When false, prevents storing the user's country from Azure AD. When true (default), country information is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_country")]
    public bool? ExtCountry { get; set; }

    /// <summary>
    /// When false, prevents storing the user's department from Azure AD. When true (default), department information is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_department")]
    public bool? ExtDepartment { get; set; }

    /// <summary>
    /// When false, prevents storing whether directory synchronization is enabled for the user. When true (default), directory sync status is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_dir_sync_enabled")]
    public bool? ExtDirSyncEnabled { get; set; }

    /// <summary>
    /// When false, prevents storing the user's email address from Azure AD. When true (default), email is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_email")]
    public bool? ExtEmail { get; set; }

    /// <summary>
    /// When false, prevents storing the token expiration time (in seconds). When true (default), expiration information is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_expires_in")]
    public bool? ExtExpiresIn { get; set; }

    /// <summary>
    /// When false, prevents storing the user's family name (last name) from Azure AD. When true (default), family name is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_family_name")]
    public bool? ExtFamilyName { get; set; }

    /// <summary>
    /// When false, prevents storing the user's fax number from Azure AD. When true (default), fax information is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_fax")]
    public bool? ExtFax { get; set; }

    /// <summary>
    /// When false, prevents storing the user's given name (first name) from Azure AD. When true (default), given name is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_given_name")]
    public bool? ExtGivenName { get; set; }

    /// <summary>
    /// When false, prevents storing the list of Azure AD group IDs the user is a member of. When true (default), group membership IDs are persisted. See ext_groups for retrieving group details.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_group_ids")]
    public bool? ExtGroupIds { get; set; }

    [Optional]
    [JsonPropertyName("ext_groups")]
    public bool? ExtGroups { get; set; }

    [Optional]
    [JsonPropertyName("ext_is_suspended")]
    public bool? ExtIsSuspended { get; set; }

    /// <summary>
    /// When false, prevents storing the user's job title from Azure AD. When true (default), job title information is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_job_title")]
    public bool? ExtJobTitle { get; set; }

    /// <summary>
    /// When false, prevents storing the timestamp of the last directory synchronization. When true (default), the last sync date is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_last_sync")]
    public bool? ExtLastSync { get; set; }

    /// <summary>
    /// When false, prevents storing the user's mobile phone number from Azure AD. When true (default), mobile number is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_mobile")]
    public bool? ExtMobile { get; set; }

    /// <summary>
    /// When false, prevents storing the user's full name from Azure AD. When true (default), full name is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_name")]
    public bool? ExtName { get; set; }

    /// <summary>
    /// When true, stores all groups the user is member of, including transitive group memberships (groups within groups). When false (default), only direct group memberships are included.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_nested_groups")]
    public bool? ExtNestedGroups { get; set; }

    /// <summary>
    /// When false, prevents storing the user's nickname or display name from Azure AD. When true (default), nickname is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_nickname")]
    public bool? ExtNickname { get; set; }

    /// <summary>
    /// When false, prevents storing the user's Object ID (oid) from Azure AD. When true (default), the oid is persisted. Note: 'oid' is the recommended unique identifier for single-tenant connections and required for SCIM.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_oid")]
    public bool? ExtOid { get; set; }

    /// <summary>
    /// When false, prevents storing the user's phone number from Azure AD. When true (default), phone number is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_phone")]
    public bool? ExtPhone { get; set; }

    /// <summary>
    /// When false, prevents storing the user's office location from Azure AD. When true (default), office location is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_physical_delivery_office_name")]
    public bool? ExtPhysicalDeliveryOfficeName { get; set; }

    /// <summary>
    /// When false, prevents storing the user's postal code from Azure AD. When true (default), postal code is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_postal_code")]
    public bool? ExtPostalCode { get; set; }

    /// <summary>
    /// When false, prevents storing the user's preferred language from Azure AD. When true (default), language preference is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_preferred_language")]
    public bool? ExtPreferredLanguage { get; set; }

    [Optional]
    [JsonPropertyName("ext_profile")]
    public bool? ExtProfile { get; set; }

    /// <summary>
    /// When false, prevents storing the list of service plans provisioned to the user. When true (default), provisioned plans are persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_provisioned_plans")]
    public bool? ExtProvisionedPlans { get; set; }

    /// <summary>
    /// When false, prevents storing provisioning errors that occurred during synchronization. When true (default), error information is persisted. Useful for troubleshooting sync issues.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_provisioning_errors")]
    public bool? ExtProvisioningErrors { get; set; }

    /// <summary>
    /// When false, prevents storing all proxy email addresses (email aliases) for the user. When true (default), proxy addresses are persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_proxy_addresses")]
    public bool? ExtProxyAddresses { get; set; }

    /// <summary>
    /// When false, prevents storing the user's Passport User ID (puid). When true (default), puid is persisted in the user profile. Legacy attribute.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_puid")]
    public bool? ExtPuid { get; set; }

    /// <summary>
    /// When false, prevents storing the Azure AD refresh token. When true (default), the refresh token is persisted for offline access. Required for token refresh in long-lived applications.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_refresh_token")]
    public bool? ExtRefreshToken { get; set; }

    /// <summary>
    /// When false, prevents storing Azure AD application roles assigned to the user. When true (default), role information is persisted. Useful for RBAC in applications.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_roles")]
    public bool? ExtRoles { get; set; }

    /// <summary>
    /// When false, prevents storing the user's state (province/region) from Azure AD. When true (default), state information is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_state")]
    public bool? ExtState { get; set; }

    /// <summary>
    /// When false, prevents storing the user's street address from Azure AD. When true (default), street address is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_street")]
    public bool? ExtStreet { get; set; }

    /// <summary>
    /// When false, prevents storing the user's telephone number from Azure AD. When true (default), telephone number is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_telephoneNumber")]
    public bool? ExtTelephoneNumber { get; set; }

    /// <summary>
    /// When false, prevents storing the user's Azure AD tenant ID. When true (default), tenant ID is persisted. Useful for identifying which Azure AD organization the user belongs to.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_tenantid")]
    public bool? ExtTenantid { get; set; }

    /// <summary>
    /// When false, prevents storing the user's User Principal Name (UPN) from Azure AD. When true (default), UPN is persisted. UPN is the user's logon name (e.g., user@contoso.com).
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_upn")]
    public bool? ExtUpn { get; set; }

    /// <summary>
    /// When false, prevents storing the user's usage location for license assignment. When true (default), usage location is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_usage_location")]
    public bool? ExtUsageLocation { get; set; }

    /// <summary>
    /// When false, prevents storing an alternative user ID. When true (default), this user ID is persisted in the user profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("ext_user_id")]
    public bool? ExtUserId { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("federated_connections_access_tokens")]
    public Optional<ConnectionFederatedConnectionsAccessTokens?> FederatedConnectionsAccessTokens { get; set; }

    /// <summary>
    /// Indicates whether admin consent has been granted for the required Azure AD permissions. Read-only status field managed by Auth0 during the OAuth authorization flow.
    /// </summary>
    [Optional]
    [JsonPropertyName("granted")]
    public bool? Granted { get; set; }

    [Optional]
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }

    [Optional]
    [JsonPropertyName("identity_api")]
    public ConnectionIdentityApiEnumAzureAd? IdentityApi { get; set; }

    [Optional]
    [JsonPropertyName("max_groups_to_retrieve")]
    public string? MaxGroupsToRetrieve { get; set; }

    [Optional]
    [JsonPropertyName("scope")]
    public IEnumerable<string>? Scope { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public ConnectionSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    [Optional]
    [JsonPropertyName("should_trust_email_verified_connection")]
    public ConnectionShouldTrustEmailVerifiedConnectionEnum? ShouldTrustEmailVerifiedConnection { get; set; }

    [Optional]
    [JsonPropertyName("tenant_domain")]
    public string? TenantDomain { get; set; }

    [Optional]
    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [Optional]
    [JsonPropertyName("thumbprints")]
    public IEnumerable<string>? Thumbprints { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("upstream_params")]
    public Optional<Dictionary<
        string,
        ConnectionUpstreamAdditionalProperties?
    >?> UpstreamParams { get; set; }

    /// <summary>
    /// Indicates WS-Federation protocol usage. When true, uses WS-Federation; when false, uses OpenID Connect.
    /// </summary>
    [Optional]
    [JsonPropertyName("use_wsfed")]
    public bool? UseWsfed { get; set; }

    [Optional]
    [JsonPropertyName("useCommonEndpoint")]
    public bool? UseCommonEndpoint { get; set; }

    [Optional]
    [JsonPropertyName("userid_attribute")]
    public ConnectionUseridAttributeEnumAzureAd? UseridAttribute { get; set; }

    [Optional]
    [JsonPropertyName("waad_protocol")]
    public ConnectionWaadProtocolEnumAzureAd? WaadProtocol { get; set; }

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
