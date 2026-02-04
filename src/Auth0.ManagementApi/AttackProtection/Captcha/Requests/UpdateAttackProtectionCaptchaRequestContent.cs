using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.AttackProtection;

[Serializable]
public record UpdateAttackProtectionCaptchaRequestContent
{
    [Optional]
    [JsonPropertyName("active_provider_id")]
    public AttackProtectionCaptchaProviderId? ActiveProviderId { get; set; }

    [Optional]
    [JsonPropertyName("arkose")]
    public AttackProtectionUpdateCaptchaArkose? Arkose { get; set; }

    [Optional]
    [JsonPropertyName("auth_challenge")]
    public AttackProtectionCaptchaAuthChallengeRequest? AuthChallenge { get; set; }

    [Optional]
    [JsonPropertyName("hcaptcha")]
    public AttackProtectionUpdateCaptchaHcaptcha? Hcaptcha { get; set; }

    [Optional]
    [JsonPropertyName("friendly_captcha")]
    public AttackProtectionUpdateCaptchaFriendlyCaptcha? FriendlyCaptcha { get; set; }

    [Optional]
    [JsonPropertyName("recaptcha_enterprise")]
    public AttackProtectionUpdateCaptchaRecaptchaEnterprise? RecaptchaEnterprise { get; set; }

    [Optional]
    [JsonPropertyName("recaptcha_v2")]
    public AttackProtectionUpdateCaptchaRecaptchaV2? RecaptchaV2 { get; set; }

    [Optional]
    [JsonPropertyName("simple_captcha")]
    public Dictionary<string, object?>? SimpleCaptcha { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
