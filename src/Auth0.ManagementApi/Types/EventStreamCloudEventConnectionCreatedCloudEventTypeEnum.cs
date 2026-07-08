using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedCloudEventTypeEnum.EventStreamCloudEventConnectionCreatedCloudEventTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedCloudEventTypeEnum : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedCloudEventTypeEnum ConnectionCreated =
        new(Values.ConnectionCreated);

    public EventStreamCloudEventConnectionCreatedCloudEventTypeEnum(string value)
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
    public static EventStreamCloudEventConnectionCreatedCloudEventTypeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventConnectionCreatedCloudEventTypeEnum(value);
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
        EventStreamCloudEventConnectionCreatedCloudEventTypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedCloudEventTypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedCloudEventTypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedCloudEventTypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedCloudEventTypeEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedCloudEventTypeEnum>
    {
        public override EventStreamCloudEventConnectionCreatedCloudEventTypeEnum Read(
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
            return new EventStreamCloudEventConnectionCreatedCloudEventTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedCloudEventTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedCloudEventTypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionCreatedCloudEventTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedCloudEventTypeEnum value,
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
        public const string ConnectionCreated = "connection.created";
    }
}
