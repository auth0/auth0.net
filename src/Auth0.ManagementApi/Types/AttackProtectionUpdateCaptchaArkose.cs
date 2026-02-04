using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record AttackProtectionUpdateCaptchaArkose : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The site key for the Arkose captcha provider.
    /// </summary>
    [JsonPropertyName("site_key")]
    public required string SiteKey { get; set; }

    /// <summary>
    /// The secret key for the Arkose captcha provider.
    /// </summary>
    [JsonPropertyName("secret")]
    public required string Secret { get; set; }

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

    /// <summary>
    /// Whether the captcha should fail open.
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
