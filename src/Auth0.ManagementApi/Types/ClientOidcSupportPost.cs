using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// OIDC support configuration for a client. Controls whether OIDC flows are allowed and which scopes the client may request.
/// </summary>
[Serializable]
public record ClientOidcSupportPost : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("is_allowed")]
    public required bool IsAllowed { get; set; }

    [Optional]
    [JsonPropertyName("allow_all_scopes")]
    public bool? AllowAllScopes { get; set; }

    [Optional]
    [JsonPropertyName("allowed_scopes")]
    public IEnumerable<ClientOidcSupportAllowedScopesEnum>? AllowedScopes { get; set; }

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
