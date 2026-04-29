using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventA0PurposeEnum.EventStreamCloudEventA0PurposeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventA0PurposeEnum : IStringEnum
{
    public static readonly EventStreamCloudEventA0PurposeEnum Test = new(Values.Test);

    public EventStreamCloudEventA0PurposeEnum(string value)
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
    public static EventStreamCloudEventA0PurposeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventA0PurposeEnum(value);
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

    public static bool operator ==(EventStreamCloudEventA0PurposeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EventStreamCloudEventA0PurposeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EventStreamCloudEventA0PurposeEnum value) => value.Value;

    public static explicit operator EventStreamCloudEventA0PurposeEnum(string value) => new(value);

    internal class EventStreamCloudEventA0PurposeEnumSerializer
        : JsonConverter<EventStreamCloudEventA0PurposeEnum>
    {
        public override EventStreamCloudEventA0PurposeEnum Read(
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
            return new EventStreamCloudEventA0PurposeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventA0PurposeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventA0PurposeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventA0PurposeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventA0PurposeEnum value,
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
        public const string Test = "test";
    }
}
