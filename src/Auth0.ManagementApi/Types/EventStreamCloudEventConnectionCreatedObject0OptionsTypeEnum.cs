using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnum.EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnum BackChannel =
        new(Values.BackChannel);

    public static readonly EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnum FrontChannel =
        new(Values.FrontChannel);

    public EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnum(string value)
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
    public static EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnum(value);
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
        EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnum>
    {
        public override EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnum Read(
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
            return new EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject0OptionsTypeEnum value,
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
        public const string BackChannel = "back_channel";

        public const string FrontChannel = "front_channel";
    }
}
