using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Allows IdP-initiated login
/// </summary>
[Serializable]
public record SelfServiceProfileSsoTicketIdpInitiatedOptions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Enables IdP-initiated login for this connection
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Default application <code>client_id</code> user is redirected to after validated SAML response
    /// </summary>
    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    [Optional]
    [JsonPropertyName("client_protocol")]
    public SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnum? ClientProtocol { get; set; }

    /// <summary>
    /// Query string options to customize the behaviour for OpenID Connect when <code>idpinitiated.client_protocol</code> is <code>oauth2</code>. Allowed parameters: <code>redirect_uri</code>, <code>scope</code>, <code>response_type</code>. For example, <code>redirect_uri=https://jwt.io&scope=openid email&response_type=token</code>
    /// </summary>
    [Optional]
    [JsonPropertyName("client_authorizequery")]
    public string? ClientAuthorizequery { get; set; }

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
