using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record ScimTokenItem : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The token's identifier
    /// </summary>
    [Optional]
    [JsonPropertyName("token_id")]
    public string? TokenId { get; set; }

    /// <summary>
    /// The scopes of the scim token
    /// </summary>
    [Optional]
    [JsonPropertyName("scopes")]
    public IEnumerable<string>? Scopes { get; set; }

    /// <summary>
    /// The token's created at timestamp
    /// </summary>
    [Optional]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The token's valid until timestamp
    /// </summary>
    [Optional]
    [JsonPropertyName("valid_until")]
    public string? ValidUntil { get; set; }

    /// <summary>
    /// The token's last used at timestamp
    /// </summary>
    [Optional]
    [JsonPropertyName("last_used_at")]
    public string? LastUsedAt { get; set; }

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
