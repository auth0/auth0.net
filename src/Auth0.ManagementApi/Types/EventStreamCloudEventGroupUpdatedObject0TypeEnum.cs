using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventGroupUpdatedObject0TypeEnum.EventStreamCloudEventGroupUpdatedObject0TypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventGroupUpdatedObject0TypeEnum : IStringEnum
{
    public static readonly EventStreamCloudEventGroupUpdatedObject0TypeEnum Connection = new(
        Values.Connection
    );

    public EventStreamCloudEventGroupUpdatedObject0TypeEnum(string value)
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
    public static EventStreamCloudEventGroupUpdatedObject0TypeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventGroupUpdatedObject0TypeEnum(value);
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
        EventStreamCloudEventGroupUpdatedObject0TypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventGroupUpdatedObject0TypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventGroupUpdatedObject0TypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventGroupUpdatedObject0TypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventGroupUpdatedObject0TypeEnumSerializer
        : JsonConverter<EventStreamCloudEventGroupUpdatedObject0TypeEnum>
    {
        public override EventStreamCloudEventGroupUpdatedObject0TypeEnum Read(
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
            return new EventStreamCloudEventGroupUpdatedObject0TypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupUpdatedObject0TypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventGroupUpdatedObject0TypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventGroupUpdatedObject0TypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupUpdatedObject0TypeEnum value,
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
