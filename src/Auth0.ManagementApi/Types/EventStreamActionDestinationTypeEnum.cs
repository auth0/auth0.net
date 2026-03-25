using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamActionDestinationTypeEnum.EventStreamActionDestinationTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamActionDestinationTypeEnum : IStringEnum
{
    public static readonly EventStreamActionDestinationTypeEnum Action = new(Values.Action);

    public EventStreamActionDestinationTypeEnum(string value)
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
    public static EventStreamActionDestinationTypeEnum FromCustom(string value)
    {
        return new EventStreamActionDestinationTypeEnum(value);
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

    public static bool operator ==(EventStreamActionDestinationTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EventStreamActionDestinationTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EventStreamActionDestinationTypeEnum value) =>
        value.Value;

    public static explicit operator EventStreamActionDestinationTypeEnum(string value) =>
        new(value);

    internal class EventStreamActionDestinationTypeEnumSerializer
        : JsonConverter<EventStreamActionDestinationTypeEnum>
    {
        public override EventStreamActionDestinationTypeEnum Read(
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
            return new EventStreamActionDestinationTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamActionDestinationTypeEnum value,
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
        public const string Action = "action";
    }
}
