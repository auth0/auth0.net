using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventGroupDeletedObject0TypeEnum.EventStreamCloudEventGroupDeletedObject0TypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventGroupDeletedObject0TypeEnum : IStringEnum
{
    public static readonly EventStreamCloudEventGroupDeletedObject0TypeEnum Connection = new(
        Values.Connection
    );

    public EventStreamCloudEventGroupDeletedObject0TypeEnum(string value)
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
    public static EventStreamCloudEventGroupDeletedObject0TypeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventGroupDeletedObject0TypeEnum(value);
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
        EventStreamCloudEventGroupDeletedObject0TypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventGroupDeletedObject0TypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventGroupDeletedObject0TypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventGroupDeletedObject0TypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventGroupDeletedObject0TypeEnumSerializer
        : JsonConverter<EventStreamCloudEventGroupDeletedObject0TypeEnum>
    {
        public override EventStreamCloudEventGroupDeletedObject0TypeEnum Read(
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
            return new EventStreamCloudEventGroupDeletedObject0TypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupDeletedObject0TypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventGroupDeletedObject0TypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventGroupDeletedObject0TypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupDeletedObject0TypeEnum value,
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
