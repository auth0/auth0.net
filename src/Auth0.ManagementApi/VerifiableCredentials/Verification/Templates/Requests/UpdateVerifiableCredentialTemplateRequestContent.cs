using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.VerifiableCredentials.Verification;

[Serializable]
public record UpdateVerifiableCredentialTemplateRequestContent
{
    [Nullable, Optional]
    [JsonPropertyName("name")]
    public Optional<string?> Name { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("type")]
    public Optional<string?> Type { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("dialect")]
    public Optional<string?> Dialect { get; set; }

    [Optional]
    [JsonPropertyName("presentation")]
    public MdlPresentationRequest? Presentation { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("well_known_trusted_issuers")]
    public Optional<string?> WellKnownTrustedIssuers { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("version")]
    public Optional<double?> Version { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
