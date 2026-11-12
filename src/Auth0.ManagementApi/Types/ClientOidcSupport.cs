using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Controls whether the client can receive ID tokens and use the UserInfo endpoint, and which user profile information it can request through OIDC scopes.
/// </summary>
[Serializable]
public record ClientOidcSupport : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Allows the client to use OIDC, including receiving ID tokens and calling the UserInfo endpoint.
    /// </summary>
    [Optional]
    [JsonPropertyName("is_allowed")]
    public bool? IsAllowed { get; set; }

    /// <summary>
    /// Allows the client to request all supported OIDC scopes. Mutually exclusive with allowed_scopes.
    /// </summary>
    [Optional]
    [JsonPropertyName("allow_all_scopes")]
    public bool? AllowAllScopes { get; set; }

    /// <summary>
    /// OIDC scopes the client may request (`profile`, `email`, `address`, and `phone`), which determine the user profile information it can access. Mutually exclusive with allow_all_scopes.
    /// </summary>
    [Optional]
    [JsonPropertyName("allowed_scopes")]
    public IEnumerable<ClientOidcSupportAllowedScopesEnum>? AllowedScopes { get; set; }

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
