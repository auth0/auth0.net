using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// SAP API addon configuration.
/// </summary>
[Serializable]
public record ClientAddonSapapi : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// If activated in the OAuth 2.0 client configuration (transaction SOAUTH2) the SAML attribute client_id must be set and equal the client_id form parameter of the access token request.
    /// </summary>
    [Optional]
    [JsonPropertyName("clientid")]
    public string? Clientid { get; set; }

    /// <summary>
    /// Name of the property in the user object that maps to a SAP username. e.g. `email`.
    /// </summary>
    [Optional]
    [JsonPropertyName("usernameAttribute")]
    public string? UsernameAttribute { get; set; }

    /// <summary>
    /// Your SAP OData server OAuth2 token endpoint URL.
    /// </summary>
    [Optional]
    [JsonPropertyName("tokenEndpointUrl")]
    public string? TokenEndpointUrl { get; set; }

    /// <summary>
    /// Requested scope for SAP APIs.
    /// </summary>
    [Optional]
    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    /// <summary>
    /// Service account password to use to authenticate API calls to the token endpoint.
    /// </summary>
    [Optional]
    [JsonPropertyName("servicePassword")]
    public string? ServicePassword { get; set; }

    /// <summary>
    /// NameID element of the Subject which can be used to express the user's identity. Defaults to `urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified`.
    /// </summary>
    [Optional]
    [JsonPropertyName("nameIdentifierFormat")]
    public string? NameIdentifierFormat { get; set; }

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
