using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.VerifiableCredentials.Verification;

[Serializable]
public record CreateVerifiableCredentialTemplateRequestContent
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("dialect")]
    public required string Dialect { get; set; }

    [JsonPropertyName("presentation")]
    public required MdlPresentationRequest Presentation { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("custom_certificate_authority")]
    public Optional<string?> CustomCertificateAuthority { get; set; }

    [JsonPropertyName("well_known_trusted_issuers")]
    public required string WellKnownTrustedIssuers { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
