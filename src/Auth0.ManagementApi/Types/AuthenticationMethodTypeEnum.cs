using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(AuthenticationMethodTypeEnum.AuthenticationMethodTypeEnumSerializer))]
[Serializable]
public readonly record struct AuthenticationMethodTypeEnum : IStringEnum
{
    public static readonly AuthenticationMethodTypeEnum RecoveryCode = new(Values.RecoveryCode);

    public static readonly AuthenticationMethodTypeEnum Totp = new(Values.Totp);

    public static readonly AuthenticationMethodTypeEnum Push = new(Values.Push);

    public static readonly AuthenticationMethodTypeEnum Phone = new(Values.Phone);

    public static readonly AuthenticationMethodTypeEnum Email = new(Values.Email);

    public static readonly AuthenticationMethodTypeEnum EmailVerification = new(
        Values.EmailVerification
    );

    public static readonly AuthenticationMethodTypeEnum WebauthnRoaming = new(
        Values.WebauthnRoaming
    );

    public static readonly AuthenticationMethodTypeEnum WebauthnPlatform = new(
        Values.WebauthnPlatform
    );

    public static readonly AuthenticationMethodTypeEnum Guardian = new(Values.Guardian);

    public static readonly AuthenticationMethodTypeEnum Passkey = new(Values.Passkey);

    public static readonly AuthenticationMethodTypeEnum Password = new(Values.Password);

    public AuthenticationMethodTypeEnum(string value)
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
    public static AuthenticationMethodTypeEnum FromCustom(string value)
    {
        return new AuthenticationMethodTypeEnum(value);
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

    public static bool operator ==(AuthenticationMethodTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AuthenticationMethodTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AuthenticationMethodTypeEnum value) => value.Value;

    public static explicit operator AuthenticationMethodTypeEnum(string value) => new(value);

    internal class AuthenticationMethodTypeEnumSerializer
        : JsonConverter<AuthenticationMethodTypeEnum>
    {
        public override AuthenticationMethodTypeEnum Read(
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
            return new AuthenticationMethodTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AuthenticationMethodTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string RecoveryCode = "recovery-code";

        public const string Totp = "totp";

        public const string Push = "push";

        public const string Phone = "phone";

        public const string Email = "email";

        public const string EmailVerification = "email-verification";

        public const string WebauthnRoaming = "webauthn-roaming";

        public const string WebauthnPlatform = "webauthn-platform";

        public const string Guardian = "guardian";

        public const string Passkey = "passkey";

        public const string Password = "password";
    }
}
