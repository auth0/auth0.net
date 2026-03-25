using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record GetAttackProtectionCaptchaResponseContent : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("active_provider_id")]
    public string? ActiveProviderId { get; set; }

    [Optional]
    [JsonPropertyName("arkose")]
    public AttackProtectionCaptchaArkoseResponseContent? Arkose { get; set; }

    [Optional]
    [JsonPropertyName("auth_challenge")]
    public AttackProtectionCaptchaAuthChallengeResponseContent? AuthChallenge { get; set; }

    [Optional]
    [JsonPropertyName("hcaptcha")]
    public AttackProtectionCaptchaHcaptchaResponseContent? Hcaptcha { get; set; }

    [Optional]
    [JsonPropertyName("friendly_captcha")]
    public AttackProtectionCaptchaFriendlyCaptchaResponseContent? FriendlyCaptcha { get; set; }

    [Optional]
    [JsonPropertyName("recaptcha_enterprise")]
    public AttackProtectionCaptchaRecaptchaEnterpriseResponseContent? RecaptchaEnterprise { get; set; }

    [Optional]
    [JsonPropertyName("recaptcha_v2")]
    public AttackProtectionCaptchaRecaptchaV2ResponseContent? RecaptchaV2 { get; set; }

    [Optional]
    [JsonPropertyName("simple_captcha")]
    public Dictionary<string, object?>? SimpleCaptcha { get; set; }

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
