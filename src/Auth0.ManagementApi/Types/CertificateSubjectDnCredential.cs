using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record CertificateSubjectDnCredential : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("credential_type")]
    public required CertificateSubjectDnCredentialTypeEnum CredentialType { get; set; }

    /// <summary>
    /// Friendly name for a credential.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Subject Distinguished Name. Mutually exclusive with `pem` property. Applies to `cert_subject_dn` credential type.
    /// </summary>
    [Optional]
    [JsonPropertyName("subject_dn")]
    public string? SubjectDn { get; set; }

    /// <summary>
    /// PEM-formatted X509 certificate. Must be JSON escaped. Mutually exclusive with `subject_dn` property.
    /// </summary>
    [Optional]
    [JsonPropertyName("pem")]
    public string? Pem { get; set; }

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
