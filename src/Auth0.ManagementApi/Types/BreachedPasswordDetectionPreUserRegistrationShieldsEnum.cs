using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(BreachedPasswordDetectionPreUserRegistrationShieldsEnum.BreachedPasswordDetectionPreUserRegistrationShieldsEnumSerializer)
)]
[Serializable]
public readonly record struct BreachedPasswordDetectionPreUserRegistrationShieldsEnum : IStringEnum
{
    public static readonly BreachedPasswordDetectionPreUserRegistrationShieldsEnum Block = new(
        Values.Block
    );

    public static readonly BreachedPasswordDetectionPreUserRegistrationShieldsEnum AdminNotification =
        new(Values.AdminNotification);

    public BreachedPasswordDetectionPreUserRegistrationShieldsEnum(string value)
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
    public static BreachedPasswordDetectionPreUserRegistrationShieldsEnum FromCustom(string value)
    {
        return new BreachedPasswordDetectionPreUserRegistrationShieldsEnum(value);
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

    public static bool operator ==(
        BreachedPasswordDetectionPreUserRegistrationShieldsEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BreachedPasswordDetectionPreUserRegistrationShieldsEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BreachedPasswordDetectionPreUserRegistrationShieldsEnum value
    ) => value.Value;

    public static explicit operator BreachedPasswordDetectionPreUserRegistrationShieldsEnum(
        string value
    ) => new(value);

    internal class BreachedPasswordDetectionPreUserRegistrationShieldsEnumSerializer
        : JsonConverter<BreachedPasswordDetectionPreUserRegistrationShieldsEnum>
    {
        public override BreachedPasswordDetectionPreUserRegistrationShieldsEnum Read(
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
            return new BreachedPasswordDetectionPreUserRegistrationShieldsEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BreachedPasswordDetectionPreUserRegistrationShieldsEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BreachedPasswordDetectionPreUserRegistrationShieldsEnum ReadAsPropertyName(
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
            return new BreachedPasswordDetectionPreUserRegistrationShieldsEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BreachedPasswordDetectionPreUserRegistrationShieldsEnum value,
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
        public const string Block = "block";

        public const string AdminNotification = "admin_notification";
    }
}
