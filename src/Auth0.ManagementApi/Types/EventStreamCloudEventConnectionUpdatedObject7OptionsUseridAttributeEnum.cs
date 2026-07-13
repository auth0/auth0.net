using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnum.EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnum Oid =
        new(Values.Oid);

    public static readonly EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnum Sub =
        new(Values.Sub);

    public EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnum(string value)
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
    public static EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnum(value);
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
        EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnum>
    {
        public override EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnum Read(
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
            return new EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject7OptionsUseridAttributeEnum value,
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
