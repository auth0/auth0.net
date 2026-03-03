using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record X509CertificateCredential : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("credential_type")]
    public required X509CertificateCredentialTypeEnum CredentialType { get; set; }

    /// <summary>
    /// Friendly name for a credential.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// PEM-formatted X509 certificate. Must be JSON escaped.
    /// </summary>
    [JsonPropertyName("pem")]
    public required string Pem { get; set; }

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
