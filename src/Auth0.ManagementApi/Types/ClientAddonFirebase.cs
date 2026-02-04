using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Google Firebase addon configuration.
/// </summary>
[Serializable]
public record ClientAddonFirebase : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Google Firebase Secret. (SDK 2 only).
    /// </summary>
    [Optional]
    [JsonPropertyName("secret")]
    public string? Secret { get; set; }

    /// <summary>
    /// Optional ID of the private key to obtain kid header in the issued token (SDK v3+ tokens only).
    /// </summary>
    [Optional]
    [JsonPropertyName("private_key_id")]
    public string? PrivateKeyId { get; set; }

    /// <summary>
    /// Private Key for signing the token (SDK v3+ tokens only).
    /// </summary>
    [Optional]
    [JsonPropertyName("private_key")]
    public string? PrivateKey { get; set; }

    /// <summary>
    /// ID of the Service Account you have created (shown as `client_email` in the generated JSON file, SDK v3+ tokens only).
    /// </summary>
    [Optional]
    [JsonPropertyName("client_email")]
    public string? ClientEmail { get; set; }

    /// <summary>
    /// Optional expiration in seconds for the generated token. Defaults to 3600 seconds (SDK v3+ tokens only).
    /// </summary>
    [Optional]
    [JsonPropertyName("lifetime_in_seconds")]
    public int? LifetimeInSeconds { get; set; }

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
