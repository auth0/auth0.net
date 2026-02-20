using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Defines `self_signed_tls_client_auth` client authentication method. If the property is defined, the client is configured to use mTLS authentication method utilizing self-signed certificate.
/// </summary>
[Serializable]
public record CreateClientAuthenticationMethodSelfSignedTlsClientAuth : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("credentials")]
    public IEnumerable<X509CertificateCredential> Credentials { get; set; } =
        new List<X509CertificateCredential>();

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
