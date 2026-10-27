using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// OIDC support configuration for this client.
/// </summary>
[Serializable]
public record ClientOidcSupport : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("is_allowed")]
    public bool? IsAllowed { get; set; }

    [Optional]
    [JsonPropertyName("allow_all_scopes")]
    public bool? AllowAllScopes { get; set; }

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
