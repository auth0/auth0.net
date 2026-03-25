using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(EventStreamStatusEnum.EventStreamStatusEnumSerializer))]
[Serializable]
public readonly record struct EventStreamStatusEnum : IStringEnum
{
    public static readonly EventStreamStatusEnum Enabled = new(Values.Enabled);

    public static readonly EventStreamStatusEnum Disabled = new(Values.Disabled);

    public EventStreamStatusEnum(string value)
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
    public static EventStreamStatusEnum FromCustom(string value)
    {
        return new EventStreamStatusEnum(value);
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

    public static bool operator ==(EventStreamStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EventStreamStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EventStreamStatusEnum value) => value.Value;

    public static explicit operator EventStreamStatusEnum(string value) => new(value);

    internal class EventStreamStatusEnumSerializer : JsonConverter<EventStreamStatusEnum>
    {
        public override EventStreamStatusEnum Read(
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
            return new EventStreamStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Enabled = "enabled";

        public const string Disabled = "disabled";
    }
}
