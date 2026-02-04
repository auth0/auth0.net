using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Defines `self_signed_tls_client_auth` client authentication method. If the property is defined, the client is configured to use mTLS authentication method utilizing self-signed certificate.
/// </summary>
[Serializable]
public record ClientAuthenticationMethodSelfSignedTlsClientAuth : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A list of unique and previously created credential IDs enabled on the client for mTLS authentication utilizing self-signed certificate.
    /// </summary>
    [JsonPropertyName("credentials")]
    public IEnumerable<CredentialId> Credentials { get; set; } = new List<CredentialId>();

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
