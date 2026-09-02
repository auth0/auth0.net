using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionDeletedPreviousObject1OptionsTypeEnum.EventStreamCloudEventConnectionDeletedPreviousObject1OptionsTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionDeletedPreviousObject1OptionsTypeEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionDeletedPreviousObject1OptionsTypeEnum BackChannel =
        new(Values.BackChannel);

    public EventStreamCloudEventConnectionDeletedPreviousObject1OptionsTypeEnum(string value)
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
    public static EventStreamCloudEventConnectionDeletedPreviousObject1OptionsTypeEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionDeletedPreviousObject1OptionsTypeEnum(value);
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
        EventStreamCloudEventConnectionDeletedPreviousObject1OptionsTypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionDeletedPreviousObject1OptionsTypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionDeletedPreviousObject1OptionsTypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionDeletedPreviousObject1OptionsTypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionDeletedPreviousObject1OptionsTypeEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionDeletedPreviousObject1OptionsTypeEnum>
    {
        public override EventStreamCloudEventConnectionDeletedPreviousObject1OptionsTypeEnum Read(
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
            return new EventStreamCloudEventConnectionDeletedPreviousObject1OptionsTypeEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedPreviousObject1OptionsTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionDeletedPreviousObject1OptionsTypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionDeletedPreviousObject1OptionsTypeEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedPreviousObject1OptionsTypeEnum value,
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
    }
}
