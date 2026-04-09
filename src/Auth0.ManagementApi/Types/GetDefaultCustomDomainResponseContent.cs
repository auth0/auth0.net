using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record GetDefaultCustomDomainResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ID of the custom domain.
    /// </summary>
    [JsonPropertyName("custom_domain_id")]
    public required string CustomDomainId { get; set; }

    /// <summary>
    /// Domain name.
    /// </summary>
    [JsonPropertyName("domain")]
    public required string Domain { get; set; }

    /// <summary>
    /// Whether this is a primary domain (true) or not (false).
    /// </summary>
    [JsonPropertyName("primary")]
    public required bool Primary { get; set; }

    /// <summary>
    /// Whether this is the default custom domain (true) or not (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("is_default")]
    public bool? IsDefault { get; set; }

    [JsonPropertyName("status")]
    public required CustomDomainStatusFilterEnum Status { get; set; }

    [JsonPropertyName("type")]
    public required CustomDomainTypeEnum Type { get; set; }

    /// <summary>
    /// Intermediate address.
    /// </summary>
    [Optional]
    [JsonPropertyName("origin_domain_name")]
    public string? OriginDomainName { get; set; }

    [Optional]
    [JsonPropertyName("verification")]
    public DomainVerification? Verification { get; set; }

    /// <summary>
    /// The HTTP header to fetch the client's IP address
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("custom_client_ip_header")]
    public Optional<string?> CustomClientIpHeader { get; set; }

    /// <summary>
    /// The TLS version policy
    /// </summary>
    [Optional]
    [JsonPropertyName("tls_policy")]
    public string? TlsPolicy { get; set; }

    [Optional]
    [JsonPropertyName("domain_metadata")]
    public Dictionary<string, string?>? DomainMetadata { get; set; }

    [Optional]
    [JsonPropertyName("certificate")]
    public DomainCertificate? Certificate { get; set; }

    /// <summary>
    /// Relying Party ID (rpId) to be used for Passkeys on this custom domain. If not present, the full domain will be used.
    /// </summary>
    [Optional]
    [JsonPropertyName("relying_party_identifier")]
    public string? RelyingPartyIdentifier { get; set; }

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
