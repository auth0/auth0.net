using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Configuration for OIDC backchannel logout initiators
/// </summary>
[Serializable]
public record ClientOidcBackchannelLogoutInitiators : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("mode")]
    public ClientOidcBackchannelLogoutInitiatorsModeEnum? Mode { get; set; }

    [Optional]
    [JsonPropertyName("selected_initiators")]
    public IEnumerable<ClientOidcBackchannelLogoutInitiatorsEnum>? SelectedInitiators { get; set; }

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
