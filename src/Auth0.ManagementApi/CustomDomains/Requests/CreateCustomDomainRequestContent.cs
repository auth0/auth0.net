using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateCustomDomainRequestContent
{
    /// <summary>
    /// Domain name.
    /// </summary>
    [JsonPropertyName("domain")]
    public required string Domain { get; set; }

    [JsonPropertyName("type")]
    public required CustomDomainProvisioningTypeEnum Type { get; set; }

    [Optional]
    [JsonPropertyName("verification_method")]
    public CustomDomainVerificationMethodEnum? VerificationMethod { get; set; }

    [Optional]
    [JsonPropertyName("tls_policy")]
    public CustomDomainTlsPolicyEnum? TlsPolicy { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("custom_client_ip_header")]
    public Optional<CustomDomainCustomClientIpHeaderEnum?> CustomClientIpHeader { get; set; }

    [Optional]
    [JsonPropertyName("domain_metadata")]
    public Dictionary<string, string?>? DomainMetadata { get; set; }

    /// <summary>
    /// Relying Party ID (rpId) to be used for Passkeys on this custom domain. If not provided, the full domain will be used.
    /// </summary>
    [Optional]
    [JsonPropertyName("relying_party_identifier")]
    public string? RelyingPartyIdentifier { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
