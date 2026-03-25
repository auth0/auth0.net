using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(GuardianEnrollmentStatus.GuardianEnrollmentStatusSerializer))]
[Serializable]
public readonly record struct GuardianEnrollmentStatus : IStringEnum
{
    public static readonly GuardianEnrollmentStatus Pending = new(Values.Pending);

    public static readonly GuardianEnrollmentStatus Confirmed = new(Values.Confirmed);

    public GuardianEnrollmentStatus(string value)
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
    public static GuardianEnrollmentStatus FromCustom(string value)
    {
        return new GuardianEnrollmentStatus(value);
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

    public static bool operator ==(GuardianEnrollmentStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GuardianEnrollmentStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GuardianEnrollmentStatus value) => value.Value;

    public static explicit operator GuardianEnrollmentStatus(string value) => new(value);

    internal class GuardianEnrollmentStatusSerializer : JsonConverter<GuardianEnrollmentStatus>
    {
        public override GuardianEnrollmentStatus Read(
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
            return new GuardianEnrollmentStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuardianEnrollmentStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GuardianEnrollmentStatus ReadAsPropertyName(
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
            return new GuardianEnrollmentStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuardianEnrollmentStatus value,
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
