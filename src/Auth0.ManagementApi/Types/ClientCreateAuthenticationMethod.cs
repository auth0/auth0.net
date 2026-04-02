using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Defines client authentication methods.
/// </summary>
[Serializable]
public record ClientCreateAuthenticationMethod : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("private_key_jwt")]
    public ClientCreateAuthenticationMethodPrivateKeyJwt? PrivateKeyJwt { get; set; }

    [Optional]
    [JsonPropertyName("tls_client_auth")]
    public ClientCreateAuthenticationMethodTlsClientAuth? TlsClientAuth { get; set; }

    [Optional]
    [JsonPropertyName("self_signed_tls_client_auth")]
    public CreateClientAuthenticationMethodSelfSignedTlsClientAuth? SelfSignedTlsClientAuth { get; set; }

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
