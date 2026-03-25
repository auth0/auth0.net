using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(BreachedPasswordDetectionPreChangePasswordShieldsEnum.BreachedPasswordDetectionPreChangePasswordShieldsEnumSerializer)
)]
[Serializable]
public readonly record struct BreachedPasswordDetectionPreChangePasswordShieldsEnum : IStringEnum
{
    public static readonly BreachedPasswordDetectionPreChangePasswordShieldsEnum Block = new(
        Values.Block
    );

    public static readonly BreachedPasswordDetectionPreChangePasswordShieldsEnum AdminNotification =
        new(Values.AdminNotification);

    public BreachedPasswordDetectionPreChangePasswordShieldsEnum(string value)
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
    public static BreachedPasswordDetectionPreChangePasswordShieldsEnum FromCustom(string value)
    {
        return new BreachedPasswordDetectionPreChangePasswordShieldsEnum(value);
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
        BreachedPasswordDetectionPreChangePasswordShieldsEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BreachedPasswordDetectionPreChangePasswordShieldsEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BreachedPasswordDetectionPreChangePasswordShieldsEnum value
    ) => value.Value;

    public static explicit operator BreachedPasswordDetectionPreChangePasswordShieldsEnum(
        string value
    ) => new(value);

    internal class BreachedPasswordDetectionPreChangePasswordShieldsEnumSerializer
        : JsonConverter<BreachedPasswordDetectionPreChangePasswordShieldsEnum>
    {
        public override BreachedPasswordDetectionPreChangePasswordShieldsEnum Read(
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
            return new BreachedPasswordDetectionPreChangePasswordShieldsEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BreachedPasswordDetectionPreChangePasswordShieldsEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BreachedPasswordDetectionPreChangePasswordShieldsEnum ReadAsPropertyName(
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
            return new BreachedPasswordDetectionPreChangePasswordShieldsEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BreachedPasswordDetectionPreChangePasswordShieldsEnum value,
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
