using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Configuration for OIDC backchannel logout
/// </summary>
[Serializable]
public record ClientOidcBackchannelLogoutSettings : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Comma-separated list of URLs that are valid to call back from Auth0 for OIDC backchannel logout. Currently only one URL is allowed.
    /// </summary>
    [Optional]
    [JsonPropertyName("backchannel_logout_urls")]
    public IEnumerable<string>? BackchannelLogoutUrls { get; set; }

    [Optional]
    [JsonPropertyName("backchannel_logout_initiators")]
    public ClientOidcBackchannelLogoutInitiators? BackchannelLogoutInitiators { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("backchannel_logout_session_metadata")]
    public Optional<ClientOidcBackchannelLogoutSessionMetadata?> BackchannelLogoutSessionMetadata { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
