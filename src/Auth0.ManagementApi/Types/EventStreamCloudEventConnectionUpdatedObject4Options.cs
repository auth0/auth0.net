using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'adfs' connection
/// </summary>
[Serializable]
public record EventStreamCloudEventConnectionUpdatedObject4Options : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ADFS federation metadata host or XML URL used to discover WS-Fed endpoints and certificates. Errors if adfs_server and fedMetadataXml are both absent.
    /// </summary>
    [Optional]
    [JsonPropertyName("adfs_server")]
    public string? AdfsServer { get; set; }

    /// <summary>
    /// Timestamp of the last certificate expiring soon notification.
    /// </summary>
    [Optional]
    [JsonPropertyName("cert_rollover_notification")]
    public DateTime? CertRolloverNotification { get; set; }

    /// <summary>
    /// Email domains associated with this connection for Home Realm Discovery (HRD). When a user's email matches one of these domains, they are automatically routed to this connection during authentication.
    /// </summary>
    [Optional]
    [JsonPropertyName("domain_aliases")]
    public IEnumerable<string>? DomainAliases { get; set; }

    /// <summary>
    /// The entity identifier (Issuer) for the ADFS Service Provider. When not provided, defaults to 'urn:auth0:{tenant}:{connection}'.
    /// </summary>
    [Optional]
    [JsonPropertyName("entityId")]
    public string? EntityId { get; set; }

    /// <summary>
    /// Inline XML alternative to 'adfs_server'. Cannot be set together with 'adfs_server'.
    /// </summary>
    [Optional]
    [JsonPropertyName("fedMetadataXml")]
    public string? FedMetadataXml { get; set; }

    /// <summary>
    /// URL for the connection icon displayed in Auth0 login pages. Accepts HTTPS URLs. Used for visual branding in authentication flows.
    /// </summary>
    [Optional]
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }

    /// <summary>
    /// An array of user fields that should not be stored in the Auth0 database (https://auth0.com/docs/security/data-security/denylist)
    /// </summary>
    [Optional]
    [JsonPropertyName("non_persistent_attrs")]
    public IEnumerable<string>? NonPersistentAttrs { get; set; }

    /// <summary>
    /// Array of certificate thumbprints (SHA-128/SHA-256/SHA-512 hex hashes) for validating SAML signatures. Used with WS-Federation protocol. Maximum 20 thumbprints. Each thumbprint must be a hexadecimal string.
    /// </summary>
    [Optional]
    [JsonPropertyName("prev_thumbprints")]
    public IEnumerable<string>? PrevThumbprints { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public EventStreamCloudEventConnectionUpdatedObject4OptionsSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    [Optional]
    [JsonPropertyName("should_trust_email_verified_connection")]
    public EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum? ShouldTrustEmailVerifiedConnection { get; set; }

    /// <summary>
    /// Passive Requestor (WS-Fed) sign-in endpoint discovered from metadata or provided explicitly.
    /// </summary>
    [Optional]
    [JsonPropertyName("signInEndpoint")]
    public string? SignInEndpoint { get; set; }

    /// <summary>
    /// Tenant domain
    /// </summary>
    [Optional]
    [JsonPropertyName("tenant_domain")]
    public string? TenantDomain { get; set; }

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
    /// Custom ADFS claim to use as the unique user identifier. When provided, this attribute is prepended to the default user_id mapping list with highest priority. Accepts a string (single ADFS claim name).
    /// </summary>
    [Optional]
    [JsonPropertyName("user_id_attribute")]
    public string? UserIdAttribute { get; set; }

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
