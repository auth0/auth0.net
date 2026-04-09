using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Auth0 client fields mapped from the Client ID Metadata Document
/// </summary>
[Serializable]
public record CimdMappedClientFields : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The URL of the Client ID Metadata Document
    /// </summary>
    [Optional]
    [JsonPropertyName("external_client_id")]
    public string? ExternalClientId { get; set; }

    /// <summary>
    /// Client name
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Application type (e.g., web, native)
    /// </summary>
    [Optional]
    [JsonPropertyName("app_type")]
    public string? AppType { get; set; }

    /// <summary>
    /// Callback URLs
    /// </summary>
    [Optional]
    [JsonPropertyName("callbacks")]
    public IEnumerable<string>? Callbacks { get; set; }

    /// <summary>
    /// Logo URI
    /// </summary>
    [Optional]
    [JsonPropertyName("logo_uri")]
    public string? LogoUri { get; set; }

    /// <summary>
    /// Human-readable brief description of this client presentable to the end-user
    /// </summary>
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// List of grant types
    /// </summary>
    [Optional]
    [JsonPropertyName("grant_types")]
    public IEnumerable<string>? GrantTypes { get; set; }

    /// <summary>
    /// Token endpoint authentication method
    /// </summary>
    [Optional]
    [JsonPropertyName("token_endpoint_auth_method")]
    public string? TokenEndpointAuthMethod { get; set; }

    /// <summary>
    /// URL for the JSON Web Key Set containing the public keys for private_key_jwt authentication
    /// </summary>
    [Optional]
    [JsonPropertyName("jwks_uri")]
    public string? JwksUri { get; set; }

    [Optional]
    [JsonPropertyName("client_authentication_methods")]
    public CimdMappedClientAuthenticationMethods? ClientAuthenticationMethods { get; set; }

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
