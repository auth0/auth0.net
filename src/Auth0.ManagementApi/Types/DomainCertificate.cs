using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Certificate information. This object is relevant only for Custom Domains with Auth0-Managed Certificates.
/// </summary>
[Serializable]
public record DomainCertificate : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("status")]
    public DomainCertificateStatusEnum? Status { get; set; }

    /// <summary>
    /// A user-friendly error message will be presented if the certificate status is provisioning_failed or renewing_failed.
    /// </summary>
    [Optional]
    [JsonPropertyName("error_msg")]
    public string? ErrorMsg { get; set; }

    [Optional]
    [JsonPropertyName("certificate_authority")]
    public DomainCertificateAuthorityEnum? CertificateAuthority { get; set; }

    /// <summary>
    /// The certificate will be renewed prior to this date.
    /// </summary>
    [Optional]
    [JsonPropertyName("renews_before")]
    public string? RenewsBefore { get; set; }

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
