using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Controls whether matched clients can receive ID tokens and use the UserInfo endpoint, and which user profile information they can request through OIDC scopes.
/// </summary>
[Serializable]
public record ClientProfileClientConfigurationOidcSupportDefaultValue : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Allows matched clients to use OIDC, including receiving ID tokens and calling the UserInfo endpoint.
    /// </summary>
    [JsonPropertyName("is_allowed")]
    public required bool IsAllowed { get; set; }

    /// <summary>
    /// Allows matched clients to request all supported OIDC scopes. Mutually exclusive with allowed_scopes.
    /// </summary>
    [Optional]
    [JsonPropertyName("allow_all_scopes")]
    public bool? AllowAllScopes { get; set; }

    /// <summary>
    /// OIDC scopes matched clients may request (`profile`, `email`, `address`, and `phone`), which determine the user profile information they can access. Mutually exclusive with allow_all_scopes.
    /// </summary>
    [Optional]
    [JsonPropertyName("allowed_scopes")]
    public IEnumerable<ClientProfileClientConfigurationOidcSupportAllowedScopesEnum>? AllowedScopes { get; set; }

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
