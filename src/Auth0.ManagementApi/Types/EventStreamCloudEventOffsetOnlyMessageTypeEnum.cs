using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventOffsetOnlyMessageTypeEnum.EventStreamCloudEventOffsetOnlyMessageTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventOffsetOnlyMessageTypeEnum : IStringEnum
{
    public static readonly EventStreamCloudEventOffsetOnlyMessageTypeEnum OffsetOnly = new(
        Values.OffsetOnly
    );

    public EventStreamCloudEventOffsetOnlyMessageTypeEnum(string value)
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
    public static EventStreamCloudEventOffsetOnlyMessageTypeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventOffsetOnlyMessageTypeEnum(value);
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
        EventStreamCloudEventOffsetOnlyMessageTypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventOffsetOnlyMessageTypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(EventStreamCloudEventOffsetOnlyMessageTypeEnum value) =>
        value.Value;

    public static explicit operator EventStreamCloudEventOffsetOnlyMessageTypeEnum(string value) =>
        new(value);

    internal class EventStreamCloudEventOffsetOnlyMessageTypeEnumSerializer
        : JsonConverter<EventStreamCloudEventOffsetOnlyMessageTypeEnum>
    {
        public override EventStreamCloudEventOffsetOnlyMessageTypeEnum Read(
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
            return new EventStreamCloudEventOffsetOnlyMessageTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOffsetOnlyMessageTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventOffsetOnlyMessageTypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventOffsetOnlyMessageTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOffsetOnlyMessageTypeEnum value,
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
        public const string OffsetOnly = "offset-only";
    }
}
