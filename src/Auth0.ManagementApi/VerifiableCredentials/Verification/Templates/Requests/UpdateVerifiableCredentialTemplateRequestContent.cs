using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.VerifiableCredentials.Verification;

[Serializable]
public record UpdateVerifiableCredentialTemplateRequestContent
{
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Optional]
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [Optional]
    [JsonPropertyName("dialect")]
    public string? Dialect { get; set; }

    [Optional]
    [JsonPropertyName("presentation")]
    public MdlPresentationRequest? Presentation { get; set; }

    [Optional]
    [JsonPropertyName("well_known_trusted_issuers")]
    public string? WellKnownTrustedIssuers { get; set; }

    [Optional]
    [JsonPropertyName("version")]
    public double? Version { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
