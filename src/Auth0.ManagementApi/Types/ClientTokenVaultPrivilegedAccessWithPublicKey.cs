using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Settings for Token Vault Privileged Access.
/// </summary>
[Serializable]
public record ClientTokenVaultPrivilegedAccessWithPublicKey : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("credentials")]
    public IEnumerable<PublicKeyCredential> Credentials { get; set; } =
        new List<PublicKeyCredential>();

    [Optional]
    [JsonPropertyName("ip_allowlist")]
    public IEnumerable<string>? IpAllowlist { get; set; }

    [Optional]
    [JsonPropertyName("grants")]
    public IEnumerable<TokenVaultPrivilegedAccessGrant>? Grants { get; set; }

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
