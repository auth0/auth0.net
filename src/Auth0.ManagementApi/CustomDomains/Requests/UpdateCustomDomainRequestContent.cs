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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
