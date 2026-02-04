using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Settings related to OIDC RP-initiated Logout
/// </summary>
[Serializable]
public record TenantOidcLogoutSettings : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Enable the end_session_endpoint URL in the .well-known discovery configuration
    /// </summary>
    [Optional]
    [JsonPropertyName("rp_logout_end_session_endpoint_discovery")]
    public bool? RpLogoutEndSessionEndpointDiscovery { get; set; }

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
