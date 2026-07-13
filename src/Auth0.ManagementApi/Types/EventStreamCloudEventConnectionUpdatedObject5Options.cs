using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'ad' connection
/// </summary>
[Serializable]
public record EventStreamCloudEventConnectionUpdatedObject5Options : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// IP address of the AD connector agent used to validate that authentication requests originate from the corporate network for Kerberos authentication  (managed by the AD Connector agent).
    /// </summary>
    [Optional]
    [JsonPropertyName("agentIP")]
    public string? AgentIp { get; set; }

    /// <summary>
    /// When enabled, allows direct username/password authentication through the AD connector agent instead of WS-Federation protocol (managed by the AD Connector agent).
    /// </summary>
    [Optional]
    [JsonPropertyName("agentMode")]
    public bool? AgentMode { get; set; }

    /// <summary>
    /// Version identifier of the installed AD connector agent software (managed by the AD Connector agent).
    /// </summary>
    [Optional]
    [JsonPropertyName("agentVersion")]
    public string? AgentVersion { get; set; }

    /// <summary>
    /// Enables Auth0's brute force protection to prevent credential stuffing attacks. When enabled, blocks suspicious login attempts from specific IP addresses after repeated failures.
    /// </summary>
    [Optional]
    [JsonPropertyName("brute_force_protection")]
    public bool? BruteForceProtection { get; set; }

    /// <summary>
    /// Enables client SSL certificate authentication for the AD connector, requiring HTTPS on the sign-in endpoint
    /// </summary>
    [Optional]
    [JsonPropertyName("certAuth")]
    public bool? CertAuth { get; set; }

    /// <summary>
    /// Array of X.509 certificates in PEM format used for validating SAML signatures from the AD identity provider (managed by the AD Connector agent).
    /// </summary>
    [Optional]
    [JsonPropertyName("certs")]
    public IEnumerable<string>? Certs { get; set; }

    /// <summary>
    /// When enabled, disables caching of AD connector authentication results to ensure real-time validation against the directory
    /// </summary>
    [Optional]
    [JsonPropertyName("disable_cache")]
    public bool? DisableCache { get; set; }

    /// <summary>
    /// When enabled, hides the 'Forgot Password' link on login pages to prevent users from initiating self-service password resets
    /// </summary>
    [Optional]
    [JsonPropertyName("disable_self_service_change_password")]
    public bool? DisableSelfServiceChangePassword { get; set; }

    /// <summary>
    /// List of domain names that can be used with identifier-first authentication flow to route users to this AD connection; each domain must be a valid DNS name up to 256 characters
    /// </summary>
    [Optional]
    [JsonPropertyName("domain_aliases")]
    public IEnumerable<string>? DomainAliases { get; set; }

    /// <summary>
    /// https url of the icon to be shown
    /// </summary>
    [Optional]
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }

    /// <summary>
    /// Array of IP address ranges in CIDR notation used to determine if authentication requests originate from the corporate network for Kerberos or certificate authentication.
    /// </summary>
    [Optional]
    [JsonPropertyName("ips")]
    public IEnumerable<string>? Ips { get; set; }

    /// <summary>
    /// Enables Windows Integrated Authentication (Kerberos) for seamless SSO when users authenticate from within the corporate network IP ranges
    /// </summary>
    [Optional]
    [JsonPropertyName("kerberos")]
    public bool? Kerberos { get; set; }

    /// <summary>
    /// An array of user fields that should not be stored in the Auth0 database (https://auth0.com/docs/security/data-security/denylist)
    /// </summary>
    [Optional]
    [JsonPropertyName("non_persistent_attrs")]
    public IEnumerable<string>? NonPersistentAttrs { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public EventStreamCloudEventConnectionUpdatedObject5OptionsSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    /// <summary>
    /// The sign-in endpoint type for the AD-LDAP connector agent (managed by the AD Connector agent).
    /// </summary>
    [Optional]
    [JsonPropertyName("signInEndpoint")]
    public string? SignInEndpoint { get; set; }

    /// <summary>
    /// Primary AD domain hint used for HRD and discovery.
    /// </summary>
    [Optional]
    [JsonPropertyName("tenant_domain")]
    public string? TenantDomain { get; set; }

    /// <summary>
    /// Array of certificate SHA-1 thumbprints for validating signatures. Managed by Auth0 when using the AD Connector agent.
    /// </summary>
    [Optional]
    [JsonPropertyName("thumbprints")]
    public IEnumerable<string>? Thumbprints { get; set; }

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
