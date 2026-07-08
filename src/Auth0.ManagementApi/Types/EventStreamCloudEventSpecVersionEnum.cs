using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventSpecVersionEnum.EventStreamCloudEventSpecVersionEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventSpecVersionEnum : IStringEnum
{
    public static readonly EventStreamCloudEventSpecVersionEnum One0 = new(Values.One0);

    public EventStreamCloudEventSpecVersionEnum(string value)
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
    public static EventStreamCloudEventSpecVersionEnum FromCustom(string value)
    {
        return new EventStreamCloudEventSpecVersionEnum(value);
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

    public static bool operator ==(EventStreamCloudEventSpecVersionEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EventStreamCloudEventSpecVersionEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EventStreamCloudEventSpecVersionEnum value) =>
        value.Value;

    public static explicit operator EventStreamCloudEventSpecVersionEnum(string value) =>
        new(value);

    internal class EventStreamCloudEventSpecVersionEnumSerializer
        : JsonConverter<EventStreamCloudEventSpecVersionEnum>
    {
        public override EventStreamCloudEventSpecVersionEnum Read(
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
            return new EventStreamCloudEventSpecVersionEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventSpecVersionEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventSpecVersionEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventSpecVersionEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventSpecVersionEnum value,
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
        public const string One0 = "1.0";
    }
}
