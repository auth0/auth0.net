using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Authentication signal details
/// </summary>
[Serializable]
public record SessionAuthenticationSignal : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// One of: "federated", "passkey", "pwd", "sms", "email", "mfa", "mock" or a custom method denoted by a URL
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Optional]
    [JsonPropertyName("timestamp")]
    public SessionDate? Timestamp { get; set; }

    /// <summary>
    /// A specific MFA factor. Only present when "name" is set to "mfa"
    /// </summary>
    [Optional]
    [JsonPropertyName("type")]
    public string? Type { get; set; }

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
