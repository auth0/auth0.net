using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record AttackProtectionCaptchaArkoseResponseContent : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The site key for the Arkose captcha provider.
    /// </summary>
    [Optional]
    [JsonPropertyName("site_key")]
    public string? SiteKey { get; set; }

    /// <summary>
    /// Whether the captcha should fail open.
    /// </summary>
    [Optional]
    [JsonPropertyName("fail_open")]
    public bool? FailOpen { get; set; }

    /// <summary>
    /// The subdomain used for client requests to the Arkose captcha provider.
    /// </summary>
    [Optional]
    [JsonPropertyName("client_subdomain")]
    public string? ClientSubdomain { get; set; }

    /// <summary>
    /// The subdomain used for server-side verification requests to the Arkose captcha provider.
    /// </summary>
    [Optional]
    [JsonPropertyName("verify_subdomain")]
    public string? VerifySubdomain { get; set; }

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
