using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateCustomDomainRequestContent
{
    [Optional]
    [JsonPropertyName("tls_policy")]
    public string? TlsPolicy { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("custom_client_ip_header")]
    public Optional<CustomDomainCustomClientIpHeaderEnum?> CustomClientIpHeader { get; set; }

    [Optional]
    [JsonPropertyName("domain_metadata")]
    public Dictionary<string, string?>? DomainMetadata { get; set; }

    /// <summary>
    /// Relying Party ID (rpId) to be used for Passkeys on this custom domain. Set to null to remove the rpId and fall back to using the full domain.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("relying_party_identifier")]
    public Optional<string?> RelyingPartyIdentifier { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
