using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Token-based authentication settings to be applied when connection is using an sms strategy.
/// </summary>
[Serializable]
public record ConnectionGatewayAuthentication : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The Authorization header type.
    /// </summary>
    [JsonPropertyName("method")]
    public required string Method { get; set; }

    /// <summary>
    /// The subject to be added to the JWT payload.
    /// </summary>
    [Optional]
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>
    /// The audience to be added to the JWT payload.
    /// </summary>
    [JsonPropertyName("audience")]
    public required string Audience { get; set; }

    /// <summary>
    /// The secret to be used for signing tokens.
    /// </summary>
    [JsonPropertyName("secret")]
    public required string Secret { get; set; }

    /// <summary>
    /// Set to true if the provided secret is base64 encoded.
    /// </summary>
    [Optional]
    [JsonPropertyName("secret_base64_encoded")]
    public bool? SecretBase64Encoded { get; set; }

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
