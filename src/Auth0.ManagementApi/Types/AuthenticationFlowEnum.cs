using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(AuthenticationFlowEnum.AuthenticationFlowEnumSerializer))]
[Serializable]
public readonly record struct AuthenticationFlowEnum : IStringEnum
{
    public static readonly AuthenticationFlowEnum Authentication = new(Values.Authentication);

    public static readonly AuthenticationFlowEnum MfaEnrollment = new(Values.MfaEnrollment);

    public static readonly AuthenticationFlowEnum MfaChallenge = new(Values.MfaChallenge);

    public static readonly AuthenticationFlowEnum PasswordReset = new(Values.PasswordReset);

    public static readonly AuthenticationFlowEnum PasskeyEnrollment = new(Values.PasskeyEnrollment);

    public static readonly AuthenticationFlowEnum All = new(Values.All);

    public AuthenticationFlowEnum(string value)
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
    public static AuthenticationFlowEnum FromCustom(string value)
    {
        return new AuthenticationFlowEnum(value);
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

    public static bool operator ==(AuthenticationFlowEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AuthenticationFlowEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AuthenticationFlowEnum value) => value.Value;

    public static explicit operator AuthenticationFlowEnum(string value) => new(value);

    internal class AuthenticationFlowEnumSerializer : JsonConverter<AuthenticationFlowEnum>
    {
        public override AuthenticationFlowEnum Read(
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
            return new AuthenticationFlowEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AuthenticationFlowEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AuthenticationFlowEnum ReadAsPropertyName(
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
            return new AuthenticationFlowEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AuthenticationFlowEnum value,
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
        public const string Authentication = "authentication";

        public const string MfaEnrollment = "mfa_enrollment";

        public const string MfaChallenge = "mfa_challenge";

        public const string PasswordReset = "password_reset";

        public const string PasskeyEnrollment = "passkey_enrollment";

        public const string All = "all";
    }
}
