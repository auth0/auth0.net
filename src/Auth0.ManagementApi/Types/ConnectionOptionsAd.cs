using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'ad' connection
/// </summary>
[Serializable]
public record ConnectionOptionsAd : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("agentIP")]
    public string? AgentIp { get; set; }

    [Optional]
    [JsonPropertyName("agentMode")]
    public bool? AgentMode { get; set; }

    [Optional]
    [JsonPropertyName("agentVersion")]
    public string? AgentVersion { get; set; }

    [Optional]
    [JsonPropertyName("brute_force_protection")]
    public bool? BruteForceProtection { get; set; }

    /// <summary>
    /// Enables client SSL certificate authentication for the AD connector, requiring HTTPS on the sign-in endpoint
    /// </summary>
    [Optional]
    [JsonPropertyName("certAuth")]
    public bool? CertAuth { get; set; }

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

    [Optional]
    [JsonPropertyName("domain_aliases")]
    public IEnumerable<string>? DomainAliases { get; set; }

    [Optional]
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }

    [Optional]
    [JsonPropertyName("ips")]
    public IEnumerable<string>? Ips { get; set; }

    /// <summary>
    /// Enables Windows Integrated Authentication (Kerberos) for seamless SSO when users authenticate from within the corporate network IP ranges
    /// </summary>
    [Optional]
    [JsonPropertyName("kerberos")]
    public bool? Kerberos { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public ConnectionSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    [Optional]
    [JsonPropertyName("signInEndpoint")]
    public string? SignInEndpoint { get; set; }

    [Optional]
    [JsonPropertyName("tenant_domain")]
    public string? TenantDomain { get; set; }

    [Optional]
    [JsonPropertyName("thumbprints")]
    public IEnumerable<string>? Thumbprints { get; set; }

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
