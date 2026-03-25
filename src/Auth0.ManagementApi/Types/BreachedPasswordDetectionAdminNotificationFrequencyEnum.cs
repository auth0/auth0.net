using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(BreachedPasswordDetectionAdminNotificationFrequencyEnum.BreachedPasswordDetectionAdminNotificationFrequencyEnumSerializer)
)]
[Serializable]
public readonly record struct BreachedPasswordDetectionAdminNotificationFrequencyEnum : IStringEnum
{
    public static readonly BreachedPasswordDetectionAdminNotificationFrequencyEnum Immediately =
        new(Values.Immediately);

    public static readonly BreachedPasswordDetectionAdminNotificationFrequencyEnum Daily = new(
        Values.Daily
    );

    public static readonly BreachedPasswordDetectionAdminNotificationFrequencyEnum Weekly = new(
        Values.Weekly
    );

    public static readonly BreachedPasswordDetectionAdminNotificationFrequencyEnum Monthly = new(
        Values.Monthly
    );

    public BreachedPasswordDetectionAdminNotificationFrequencyEnum(string value)
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
    public static BreachedPasswordDetectionAdminNotificationFrequencyEnum FromCustom(string value)
    {
        return new BreachedPasswordDetectionAdminNotificationFrequencyEnum(value);
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
        BreachedPasswordDetectionAdminNotificationFrequencyEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BreachedPasswordDetectionAdminNotificationFrequencyEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BreachedPasswordDetectionAdminNotificationFrequencyEnum value
    ) => value.Value;

    public static explicit operator BreachedPasswordDetectionAdminNotificationFrequencyEnum(
        string value
    ) => new(value);

    internal class BreachedPasswordDetectionAdminNotificationFrequencyEnumSerializer
        : JsonConverter<BreachedPasswordDetectionAdminNotificationFrequencyEnum>
    {
        public override BreachedPasswordDetectionAdminNotificationFrequencyEnum Read(
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
            return new BreachedPasswordDetectionAdminNotificationFrequencyEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BreachedPasswordDetectionAdminNotificationFrequencyEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BreachedPasswordDetectionAdminNotificationFrequencyEnum ReadAsPropertyName(
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
            return new BreachedPasswordDetectionAdminNotificationFrequencyEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BreachedPasswordDetectionAdminNotificationFrequencyEnum value,
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
        public const string Immediately = "immediately";

        public const string Daily = "daily";

        public const string Weekly = "weekly";

        public const string Monthly = "monthly";
    }
}
