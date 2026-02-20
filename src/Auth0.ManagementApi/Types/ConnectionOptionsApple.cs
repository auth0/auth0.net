using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'apple' connection
/// </summary>
[Serializable]
public record ConnectionOptionsApple : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Apple App Secret (must be a PEM)
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("app_secret")]
    public Optional<string?> AppSecret { get; set; }

    /// <summary>
    /// Apple Services ID
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("client_id")]
    public Optional<string?> ClientId { get; set; }

    /// <summary>
    /// User has the option to obfuscate the email with Apple's relay service
    /// </summary>
    [Optional]
    [JsonPropertyName("email")]
    public bool? Email { get; set; }

    /// <summary>
    /// Array of freeform scopes
    /// </summary>
    [Optional]
    [JsonPropertyName("freeform_scopes")]
    public IEnumerable<string>? FreeformScopes { get; set; }

    /// <summary>
    /// Apple Key ID
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("kid")]
    public Optional<string?> Kid { get; set; }

    /// <summary>
    /// Whether to request name from Apple
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public bool? Name { get; set; }

    /// <summary>
    /// Space separated list of scopes
    /// </summary>
    [Optional]
    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public ConnectionSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    /// <summary>
    /// Apple Team ID
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("team_id")]
    public Optional<string?> TeamId { get; set; }

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
