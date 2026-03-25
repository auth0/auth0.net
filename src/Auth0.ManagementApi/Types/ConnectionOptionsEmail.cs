using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'email' connection
/// </summary>
[Serializable]
public record ConnectionOptionsEmail : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("authParams")]
    public string? AuthParams { get; set; }

    [JsonPropertyName("brute_force_protection")]
    public required bool BruteForceProtection { get; set; }

    [Optional]
    [JsonPropertyName("disable_signup")]
    public bool? DisableSignup { get; set; }

    [JsonPropertyName("email")]
    public required ConnectionEmailEmail Email { get; set; }

    /// <summary>
    /// Connection name
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [Optional]
    [JsonPropertyName("totp")]
    public ConnectionTotpEmail? Totp { get; set; }

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
