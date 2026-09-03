using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventGroupDeletedPreviousObject0TypeEnum.EventStreamCloudEventGroupDeletedPreviousObject0TypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventGroupDeletedPreviousObject0TypeEnum : IStringEnum
{
    public static readonly EventStreamCloudEventGroupDeletedPreviousObject0TypeEnum Connection =
        new(Values.Connection);

    public EventStreamCloudEventGroupDeletedPreviousObject0TypeEnum(string value)
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
    public static EventStreamCloudEventGroupDeletedPreviousObject0TypeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventGroupDeletedPreviousObject0TypeEnum(value);
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
        EventStreamCloudEventGroupDeletedPreviousObject0TypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventGroupDeletedPreviousObject0TypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventGroupDeletedPreviousObject0TypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventGroupDeletedPreviousObject0TypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventGroupDeletedPreviousObject0TypeEnumSerializer
        : JsonConverter<EventStreamCloudEventGroupDeletedPreviousObject0TypeEnum>
    {
        public override EventStreamCloudEventGroupDeletedPreviousObject0TypeEnum Read(
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
            return new EventStreamCloudEventGroupDeletedPreviousObject0TypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupDeletedPreviousObject0TypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventGroupDeletedPreviousObject0TypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventGroupDeletedPreviousObject0TypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupDeletedPreviousObject0TypeEnum value,
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
        public const string Connection = "connection";
    }
}
