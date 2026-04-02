using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Configuration related to JWTs for the client.
/// </summary>
[Serializable]
public record ClientJwtConfiguration : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Number of seconds the JWT will be valid for (affects `exp` claim).
    /// </summary>
    [Optional]
    [JsonPropertyName("lifetime_in_seconds")]
    public int? LifetimeInSeconds { get; set; }

    /// <summary>
    /// Whether the client secret is base64 encoded (true) or unencoded (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("secret_encoded")]
    public bool? SecretEncoded { get; set; }

    [Optional]
    [JsonPropertyName("scopes")]
    public Dictionary<string, object?>? Scopes { get; set; }

    [Optional]
    [JsonPropertyName("alg")]
    public SigningAlgorithmEnum? Alg { get; set; }

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
