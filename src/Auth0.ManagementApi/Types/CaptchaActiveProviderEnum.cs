using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CaptchaActiveProviderEnum.CaptchaActiveProviderEnumSerializer))]
[Serializable]
public readonly record struct CaptchaActiveProviderEnum : IStringEnum
{
    public static readonly CaptchaActiveProviderEnum SimpleCaptcha = new(Values.SimpleCaptcha);

    public static readonly CaptchaActiveProviderEnum AuthChallenge = new(Values.AuthChallenge);

    public static readonly CaptchaActiveProviderEnum RecaptchaV2 = new(Values.RecaptchaV2);

    public static readonly CaptchaActiveProviderEnum RecaptchaEnterprise = new(
        Values.RecaptchaEnterprise
    );

    public static readonly CaptchaActiveProviderEnum Hcaptcha = new(Values.Hcaptcha);

    public static readonly CaptchaActiveProviderEnum FriendlyCaptcha = new(Values.FriendlyCaptcha);

    public static readonly CaptchaActiveProviderEnum Arkose = new(Values.Arkose);

    public CaptchaActiveProviderEnum(string value)
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
    public static CaptchaActiveProviderEnum FromCustom(string value)
    {
        return new CaptchaActiveProviderEnum(value);
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

    public static bool operator ==(CaptchaActiveProviderEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CaptchaActiveProviderEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CaptchaActiveProviderEnum value) => value.Value;

    public static explicit operator CaptchaActiveProviderEnum(string value) => new(value);

    internal class CaptchaActiveProviderEnumSerializer : JsonConverter<CaptchaActiveProviderEnum>
    {
        public override CaptchaActiveProviderEnum Read(
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
            return new CaptchaActiveProviderEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CaptchaActiveProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CaptchaActiveProviderEnum ReadAsPropertyName(
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
            return new CaptchaActiveProviderEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CaptchaActiveProviderEnum value,
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
        public const string SimpleCaptcha = "simple_captcha";

        public const string AuthChallenge = "auth_challenge";

        public const string RecaptchaV2 = "recaptcha_v2";

        public const string RecaptchaEnterprise = "recaptcha_enterprise";

        public const string Hcaptcha = "hcaptcha";

        public const string FriendlyCaptcha = "friendly_captcha";

        public const string Arkose = "arkose";
    }
}
