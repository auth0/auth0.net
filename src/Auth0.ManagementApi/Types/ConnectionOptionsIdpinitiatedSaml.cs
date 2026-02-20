using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Configuration for IdP-Initiated SAML Single Sign-On. When enabled, allows users to initiate login directly from their SAML identity provider without first visiting Auth0. The IdP must include the connection parameter in the post-back URL (Assertion Consumer Service URL).
/// </summary>
[Serializable]
public record ConnectionOptionsIdpinitiatedSaml : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The query string sent to the default application
    /// </summary>
    [Optional]
    [JsonPropertyName("client_authorizequery")]
    public string? ClientAuthorizequery { get; set; }

    /// <summary>
    /// The client ID to use for IdP-initiated login requests.
    /// </summary>
    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    [Optional]
    [JsonPropertyName("client_protocol")]
    public ConnectionOptionsIdpInitiatedClientProtocolEnumSaml? ClientProtocol { get; set; }

    /// <summary>
    /// When true, enables IdP-initiated login support for this SAML connection. Allows users to log in directly from the identity provider without first visiting Auth0.
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

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
