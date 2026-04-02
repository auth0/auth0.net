using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateScimTokenResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The token's identifier
    /// </summary>
    [Optional]
    [JsonPropertyName("token_id")]
    public string? TokenId { get; set; }

    /// <summary>
    /// The scim client's token
    /// </summary>
    [Optional]
    [JsonPropertyName("token")]
    public string? Token { get; set; }

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
    /// The token's valid until at timestamp
    /// </summary>
    [Optional]
    [JsonPropertyName("valid_until")]
    public string? ValidUntil { get; set; }

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
