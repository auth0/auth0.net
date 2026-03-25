using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(GuardianEnrollmentFactorEnum.GuardianEnrollmentFactorEnumSerializer))]
[Serializable]
public readonly record struct GuardianEnrollmentFactorEnum : IStringEnum
{
    public static readonly GuardianEnrollmentFactorEnum PushNotification = new(
        Values.PushNotification
    );

    public static readonly GuardianEnrollmentFactorEnum Phone = new(Values.Phone);

    public static readonly GuardianEnrollmentFactorEnum Email = new(Values.Email);

    public static readonly GuardianEnrollmentFactorEnum Otp = new(Values.Otp);

    public static readonly GuardianEnrollmentFactorEnum WebauthnRoaming = new(
        Values.WebauthnRoaming
    );

    public static readonly GuardianEnrollmentFactorEnum WebauthnPlatform = new(
        Values.WebauthnPlatform
    );

    public GuardianEnrollmentFactorEnum(string value)
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
    public static GuardianEnrollmentFactorEnum FromCustom(string value)
    {
        return new GuardianEnrollmentFactorEnum(value);
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

    public static bool operator ==(GuardianEnrollmentFactorEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GuardianEnrollmentFactorEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GuardianEnrollmentFactorEnum value) => value.Value;

    public static explicit operator GuardianEnrollmentFactorEnum(string value) => new(value);

    internal class GuardianEnrollmentFactorEnumSerializer
        : JsonConverter<GuardianEnrollmentFactorEnum>
    {
        public override GuardianEnrollmentFactorEnum Read(
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
            return new GuardianEnrollmentFactorEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuardianEnrollmentFactorEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GuardianEnrollmentFactorEnum ReadAsPropertyName(
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
            return new GuardianEnrollmentFactorEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuardianEnrollmentFactorEnum value,
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
        public const string PushNotification = "push-notification";

        public const string Phone = "phone";

        public const string Email = "email";

        public const string Otp = "otp";

        public const string WebauthnRoaming = "webauthn-roaming";

        public const string WebauthnPlatform = "webauthn-platform";
    }
}
