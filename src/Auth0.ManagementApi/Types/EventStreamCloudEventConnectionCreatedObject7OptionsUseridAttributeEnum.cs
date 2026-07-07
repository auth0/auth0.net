using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnum.EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnum Oid =
        new(Values.Oid);

    public static readonly EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnum Sub =
        new(Values.Sub);

    public EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnum(string value)
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
    public static EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnum(value);
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
        EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnum>
    {
        public override EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnum Read(
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
            return new EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject7OptionsUseridAttributeEnum value,
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
        public const string Oid = "oid";

        public const string Sub = "sub";
    }
}
