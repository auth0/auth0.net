using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// hCaptcha provider configuration.
/// </summary>
[Serializable]
public record CaptchaPolicyActionHcaptchaInput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The hCaptcha site key.
    /// </summary>
    [Optional]
    [JsonPropertyName("site_key")]
    public string? SiteKey { get; set; }

    /// <summary>
    /// The hCaptcha secret key. Encrypted at rest.
    /// </summary>
    [Optional]
    [JsonPropertyName("secret")]
    public string? Secret { get; set; }

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
