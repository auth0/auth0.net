using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventUserDeletedCloudEventTypeEnum.EventStreamCloudEventUserDeletedCloudEventTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventUserDeletedCloudEventTypeEnum : IStringEnum
{
    public static readonly EventStreamCloudEventUserDeletedCloudEventTypeEnum UserDeleted = new(
        Values.UserDeleted
    );

    public EventStreamCloudEventUserDeletedCloudEventTypeEnum(string value)
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
    public static EventStreamCloudEventUserDeletedCloudEventTypeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventUserDeletedCloudEventTypeEnum(value);
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
        EventStreamCloudEventUserDeletedCloudEventTypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventUserDeletedCloudEventTypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventUserDeletedCloudEventTypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventUserDeletedCloudEventTypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventUserDeletedCloudEventTypeEnumSerializer
        : JsonConverter<EventStreamCloudEventUserDeletedCloudEventTypeEnum>
    {
        public override EventStreamCloudEventUserDeletedCloudEventTypeEnum Read(
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
            return new EventStreamCloudEventUserDeletedCloudEventTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserDeletedCloudEventTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventUserDeletedCloudEventTypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventUserDeletedCloudEventTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserDeletedCloudEventTypeEnum value,
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
        public const string UserDeleted = "user.deleted";
    }
}
