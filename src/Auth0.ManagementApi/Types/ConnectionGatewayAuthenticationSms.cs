using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Optional token-based authentication configuration for the SMS gateway
/// </summary>
[Serializable]
public record ConnectionGatewayAuthenticationSms : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [JsonPropertyName("audience")]
    public required string Audience { get; set; }

    [JsonPropertyName("method")]
    public required string Method { get; set; }

    /// <summary>
    /// The secret used to sign the JSON Web Token sent to the SMS gateway
    /// </summary>
    [JsonPropertyName("secret")]
    public required string Secret { get; set; }

    /// <summary>
    /// Set to true if the secret is base64-url-encoded
    /// </summary>
    [Optional]
    [JsonPropertyName("secret_base64_encoded")]
    public bool? SecretBase64Encoded { get; set; }

    [Optional]
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

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
