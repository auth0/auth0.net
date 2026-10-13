using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Arkose Labs provider configuration.
/// </summary>
[Serializable]
public record CaptchaPolicyActionArkoseInput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The Arkose Labs site key.
    /// </summary>
    [Optional]
    [JsonPropertyName("site_key")]
    public string? SiteKey { get; set; }

    /// <summary>
    /// The Arkose Labs private key. Encrypted at rest.
    /// </summary>
    [Optional]
    [JsonPropertyName("secret")]
    public string? Secret { get; set; }

    /// <summary>
    /// The Arkose Labs client subdomain.
    /// </summary>
    [Optional]
    [JsonPropertyName("client_subdomain")]
    public string? ClientSubdomain { get; set; }

    /// <summary>
    /// The Arkose Labs verify subdomain.
    /// </summary>
    [Optional]
    [JsonPropertyName("verify_subdomain")]
    public string? VerifySubdomain { get; set; }

    /// <summary>
    /// Whether to allow access when Arkose Labs is unavailable.
    /// </summary>
    [Optional]
    [JsonPropertyName("fail_open")]
    public bool? FailOpen { get; set; }

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
