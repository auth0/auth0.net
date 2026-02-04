using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Layer addon configuration.
/// </summary>
[Serializable]
public record ClientAddonLayer : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Provider ID of your Layer account
    /// </summary>
    [JsonPropertyName("providerId")]
    public required string ProviderId { get; set; }

    /// <summary>
    /// Authentication Key identifier used to sign the Layer token.
    /// </summary>
    [JsonPropertyName("keyId")]
    public required string KeyId { get; set; }

    /// <summary>
    /// Private key for signing the Layer token.
    /// </summary>
    [JsonPropertyName("privateKey")]
    public required string PrivateKey { get; set; }

    /// <summary>
    /// Name of the property used as the unique user id in Layer. If not specified `user_id` is used.
    /// </summary>
    [Optional]
    [JsonPropertyName("principal")]
    public string? Principal { get; set; }

    /// <summary>
    /// Optional expiration in minutes for the generated token. Defaults to 5 minutes.
    /// </summary>
    [Optional]
    [JsonPropertyName("expiration")]
    public int? Expiration { get; set; }

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
