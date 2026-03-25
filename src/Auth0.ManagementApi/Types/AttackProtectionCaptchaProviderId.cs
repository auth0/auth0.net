using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(AttackProtectionCaptchaProviderId.AttackProtectionCaptchaProviderIdSerializer)
)]
[Serializable]
public readonly record struct AttackProtectionCaptchaProviderId : IStringEnum
{
    public static readonly AttackProtectionCaptchaProviderId Arkose = new(Values.Arkose);

    public static readonly AttackProtectionCaptchaProviderId AuthChallenge = new(
        Values.AuthChallenge
    );

    public static readonly AttackProtectionCaptchaProviderId FriendlyCaptcha = new(
        Values.FriendlyCaptcha
    );

    public static readonly AttackProtectionCaptchaProviderId Hcaptcha = new(Values.Hcaptcha);

    public static readonly AttackProtectionCaptchaProviderId RecaptchaV2 = new(Values.RecaptchaV2);

    public static readonly AttackProtectionCaptchaProviderId RecaptchaEnterprise = new(
        Values.RecaptchaEnterprise
    );

    public static readonly AttackProtectionCaptchaProviderId SimpleCaptcha = new(
        Values.SimpleCaptcha
    );

    public AttackProtectionCaptchaProviderId(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static AttackProtectionCaptchaProviderId FromCustom(string value)
    {
        return new AttackProtectionCaptchaProviderId(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(AttackProtectionCaptchaProviderId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AttackProtectionCaptchaProviderId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AttackProtectionCaptchaProviderId value) => value.Value;

    public static explicit operator AttackProtectionCaptchaProviderId(string value) => new(value);

    internal class AttackProtectionCaptchaProviderIdSerializer
        : JsonConverter<AttackProtectionCaptchaProviderId>
    {
        public override AttackProtectionCaptchaProviderId Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new AttackProtectionCaptchaProviderId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AttackProtectionCaptchaProviderId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AttackProtectionCaptchaProviderId ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new AttackProtectionCaptchaProviderId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AttackProtectionCaptchaProviderId value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Arkose = "arkose";

        public const string AuthChallenge = "auth_challenge";

        public const string FriendlyCaptcha = "friendly_captcha";

        public const string Hcaptcha = "hcaptcha";

        public const string RecaptchaV2 = "recaptcha_v2";

        public const string RecaptchaEnterprise = "recaptcha_enterprise";

        public const string SimpleCaptcha = "simple_captcha";
    }
}
