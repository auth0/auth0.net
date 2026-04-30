using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventErrorCodeEnum.EventStreamCloudEventErrorCodeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventErrorCodeEnum : IStringEnum
{
    public static readonly EventStreamCloudEventErrorCodeEnum InvalidCursor = new(
        Values.InvalidCursor
    );

    public static readonly EventStreamCloudEventErrorCodeEnum CursorExpired = new(
        Values.CursorExpired
    );

    public static readonly EventStreamCloudEventErrorCodeEnum Timeout = new(Values.Timeout);

    public static readonly EventStreamCloudEventErrorCodeEnum PayloadTooLarge = new(
        Values.PayloadTooLarge
    );

    public static readonly EventStreamCloudEventErrorCodeEnum ProcessingError = new(
        Values.ProcessingError
    );

    public static readonly EventStreamCloudEventErrorCodeEnum ConnectionTimeout = new(
        Values.ConnectionTimeout
    );

    public EventStreamCloudEventErrorCodeEnum(string value)
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
    public static EventStreamCloudEventErrorCodeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventErrorCodeEnum(value);
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

    public static bool operator ==(EventStreamCloudEventErrorCodeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EventStreamCloudEventErrorCodeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EventStreamCloudEventErrorCodeEnum value) => value.Value;

    public static explicit operator EventStreamCloudEventErrorCodeEnum(string value) => new(value);

    internal class EventStreamCloudEventErrorCodeEnumSerializer
        : JsonConverter<EventStreamCloudEventErrorCodeEnum>
    {
        public override EventStreamCloudEventErrorCodeEnum Read(
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
            return new EventStreamCloudEventErrorCodeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventErrorCodeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventErrorCodeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventErrorCodeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventErrorCodeEnum value,
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
        public const string InvalidCursor = "invalid_cursor";

        public const string CursorExpired = "cursor_expired";

        public const string Timeout = "timeout";

        public const string PayloadTooLarge = "payload_too_large";

        public const string ProcessingError = "processing_error";

        public const string ConnectionTimeout = "connection_timeout";
    }
}
