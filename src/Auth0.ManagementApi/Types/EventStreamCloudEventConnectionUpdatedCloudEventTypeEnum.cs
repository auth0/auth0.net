using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionUpdatedCloudEventTypeEnum.EventStreamCloudEventConnectionUpdatedCloudEventTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionUpdatedCloudEventTypeEnum : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionUpdatedCloudEventTypeEnum ConnectionUpdated =
        new(Values.ConnectionUpdated);

    public EventStreamCloudEventConnectionUpdatedCloudEventTypeEnum(string value)
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
    public static EventStreamCloudEventConnectionUpdatedCloudEventTypeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventConnectionUpdatedCloudEventTypeEnum(value);
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
        EventStreamCloudEventConnectionUpdatedCloudEventTypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionUpdatedCloudEventTypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionUpdatedCloudEventTypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionUpdatedCloudEventTypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionUpdatedCloudEventTypeEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionUpdatedCloudEventTypeEnum>
    {
        public override EventStreamCloudEventConnectionUpdatedCloudEventTypeEnum Read(
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
            return new EventStreamCloudEventConnectionUpdatedCloudEventTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedCloudEventTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionUpdatedCloudEventTypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionUpdatedCloudEventTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedCloudEventTypeEnum value,
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
        public const string ConnectionUpdated = "connection.updated";
    }
}
