using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(UserEnrollmentStatusEnum.UserEnrollmentStatusEnumSerializer))]
[Serializable]
public readonly record struct UserEnrollmentStatusEnum : IStringEnum
{
    public static readonly UserEnrollmentStatusEnum Pending = new(Values.Pending);

    public static readonly UserEnrollmentStatusEnum Confirmed = new(Values.Confirmed);

    public UserEnrollmentStatusEnum(string value)
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
    public static UserEnrollmentStatusEnum FromCustom(string value)
    {
        return new UserEnrollmentStatusEnum(value);
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

    public static bool operator ==(UserEnrollmentStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UserEnrollmentStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UserEnrollmentStatusEnum value) => value.Value;

    public static explicit operator UserEnrollmentStatusEnum(string value) => new(value);

    internal class UserEnrollmentStatusEnumSerializer : JsonConverter<UserEnrollmentStatusEnum>
    {
        public override UserEnrollmentStatusEnum Read(
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
            return new UserEnrollmentStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UserEnrollmentStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UserEnrollmentStatusEnum ReadAsPropertyName(
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
            return new UserEnrollmentStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UserEnrollmentStatusEnum value,
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
        public const string Pending = "pending";

        public const string Confirmed = "confirmed";
    }
}
