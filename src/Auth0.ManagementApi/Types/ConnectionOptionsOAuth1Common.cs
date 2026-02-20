using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record ConnectionOptionsOAuth1Common : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// OAuth 1.0 client identifier issued by the identity provider during application registration. This value identifies your Auth0 connection to the identity provider.
    /// </summary>
    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    /// <summary>
    /// OAuth 1.0 client secret issued by the identity provider during application registration. Used to authenticate your Auth0 connection when signing requests and exchanging request tokens and verifiers for access tokens. May be null for public clients.
    /// </summary>
    [Optional]
    [JsonPropertyName("client_secret")]
    public string? ClientSecret { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public ConnectionSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("upstream_params")]
    public Optional<Dictionary<
        string,
        ConnectionUpstreamAdditionalProperties?
    >?> UpstreamParams { get; set; }

    [Optional]
    [JsonPropertyName("non_persistent_attrs")]
    public IEnumerable<string>? NonPersistentAttrs { get; set; }

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
