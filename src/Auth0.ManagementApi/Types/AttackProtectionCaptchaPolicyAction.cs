using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// CAPTCHA configuration override stored for this policy.
/// </summary>
[Serializable]
public record AttackProtectionCaptchaPolicyAction : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("active_provider_id")]
    public CaptchaActiveProviderEnum? ActiveProviderId { get; set; }

    [Optional]
    [JsonPropertyName("simple_captcha")]
    public CaptchaPolicyActionSimpleCaptcha? SimpleCaptcha { get; set; }

    [Optional]
    [JsonPropertyName("auth_challenge")]
    public CaptchaPolicyActionAuthChallenge? AuthChallenge { get; set; }

    [Optional]
    [JsonPropertyName("recaptcha_v2")]
    public CaptchaPolicyActionRecaptchaV2? RecaptchaV2 { get; set; }

    [Optional]
    [JsonPropertyName("recaptcha_enterprise")]
    public CaptchaPolicyActionRecaptchaEnterprise? RecaptchaEnterprise { get; set; }

    [Optional]
    [JsonPropertyName("hcaptcha")]
    public CaptchaPolicyActionHcaptcha? Hcaptcha { get; set; }

    [Optional]
    [JsonPropertyName("friendly_captcha")]
    public CaptchaPolicyActionFriendlyCaptcha? FriendlyCaptcha { get; set; }

    [Optional]
    [JsonPropertyName("arkose")]
    public CaptchaPolicyActionArkose? Arkose { get; set; }

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
