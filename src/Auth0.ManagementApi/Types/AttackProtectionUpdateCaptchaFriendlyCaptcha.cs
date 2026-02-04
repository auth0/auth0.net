using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record AttackProtectionUpdateCaptchaFriendlyCaptcha : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The site key for the Friendly Captcha provider.
    /// </summary>
    [JsonPropertyName("site_key")]
    public required string SiteKey { get; set; }

    /// <summary>
    /// The secret key for the Friendly Captcha provider.
    /// </summary>
    [JsonPropertyName("secret")]
    public required string Secret { get; set; }

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
